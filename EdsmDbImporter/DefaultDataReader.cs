using EdsmDbImporter.ResultWriters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdsmDbImporter
{
    public class DefaultDataReader<T> : IDataReader<T>, IDisposable where T : new()
    {
        private readonly string _filePath;
        private readonly StreamReader _streamReader;
        private JsonTextReader _jsonReader;
        private readonly JsonSerializer _serializer;
        public IList<string> DeserializationErrors
        {
            get
            {
                return _deserializationErrors;
            }
        }
        private IList<string> _deserializationErrors;
        private readonly long _skipEntriesCount;
        private long _entriesReadCount;
        private readonly ILogger<DefaultDataReader<T>> _logger;

        public T Result { get; private set; }

        public DefaultDataReader(string filePath, ILogger<DefaultDataReader<T>> logger, long skipEntriesCount)
        {
            _filePath = filePath;
            _streamReader = string.IsNullOrEmpty(filePath) ? new StreamReader(new MemoryStream()) : new StreamReader(filePath);
            _jsonReader = new JsonTextReader(_streamReader);
            _jsonReader.SupportMultipleContent = true;
            _serializer = new JsonSerializer();
            _serializer.Error += OnError;
            _serializer.MissingMemberHandling = MissingMemberHandling.Error;
            _deserializationErrors = new List<string>();
            _skipEntriesCount = skipEntriesCount;
            _entriesReadCount = 0;
            _logger = logger;
        }

        public void Dispose()
        {
            _jsonReader.Close();
            _streamReader.Dispose();
        }

        private void ResetReaders()
        {
            _streamReader.BaseStream.Position = 0;
            _streamReader.DiscardBufferedData();
            _jsonReader = new JsonTextReader(_streamReader);
            _jsonReader.SupportMultipleContent = true;
        }

        public async Task<bool> ValidateAsync()
        {
            ResetReaders();
            _deserializationErrors = new List<string>();
            while (await _jsonReader.ReadAsync())
            {
                if (_jsonReader.TokenType == JsonToken.StartObject)
                    _serializer.Deserialize<T>(_jsonReader);
            }
            ResetReaders();
            return !_deserializationErrors.Any();
        }

        private void OnError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
        {
            _logger.LogError(args.ErrorContext.Error.Message);
            _deserializationErrors.Add(args.ErrorContext.Error.Message);
            args.ErrorContext.Handled = true;
        }

        public async Task<bool> ReadAsync()
        {
            long skippedEntriesCount = 0;
            while (await _jsonReader.ReadAsync())
            {
                if (_jsonReader.TokenType == JsonToken.StartObject && _jsonReader.Depth == 1)
                {
                    _entriesReadCount++;
                    if (_entriesReadCount <= _skipEntriesCount)
                    {
                        _serializer.Deserialize<T>(_jsonReader);
                        _logger.LogInformation($"Entries skipped: {++skippedEntriesCount}");
                        continue;
                    }
                    Result = _serializer.Deserialize<T>(_jsonReader);
                    return true;
                }
            }
            _logger.LogInformation($"Total entries Count: {_entriesReadCount}");
            return false;
        }
    }
}
