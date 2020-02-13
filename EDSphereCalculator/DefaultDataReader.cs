using EDSphereCalculator.CalculatorModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator
{
    public class DefaultDataReader<T> : IDataReader<T>, IDisposable where T : new()
    {
        private readonly CmdOptions _options;
        private readonly StreamReader _streamReader;
        private readonly JsonTextReader _jsonReader;
        private readonly JsonSerializer _serializer;
        public T Result { get; private set; }

        public DefaultDataReader(CmdOptions options)
        {
            _options = options;
            _streamReader = new StreamReader(_options.EdsmStarDataPath);
            _jsonReader = new JsonTextReader(_streamReader);
            _jsonReader.SupportMultipleContent = true;
            _serializer = new JsonSerializer();
        }

        public void Dispose()
        {
            _jsonReader.Close();
            _streamReader.Dispose();
        }

        public async Task<bool> ReadAsync()
        {
            while(await _jsonReader.ReadAsync())
            {
                if (_jsonReader.TokenType == JsonToken.StartObject)
                {
                    Result = _serializer.Deserialize<T>(_jsonReader);
                    return true;
                }
            }
            return false;
        }
    }
}
