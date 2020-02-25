using CsvHelper;
using CsvHelper.Configuration;
using EdsmDbImporter.Mappers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EdsmDbImporter.ResultWriters
{
    public class CsvResultWriter<T1, T2> : IResultWriter<T1>, IDisposable 
        where T1 : new()
        where T2 : ClassMap
    {
        private readonly StreamWriter _streamWriter;
        private readonly CsvWriter _csvWriter;
        private readonly bool _isEnabled = true;
        private object _lockObject = new object();
        private readonly string _outputPath;

        public CsvResultWriter(string outputPath)
        {
            _outputPath = outputPath;
            if (string.IsNullOrEmpty(_outputPath))
            {
                _isEnabled = false;
                return;
            }
            _streamWriter = new StreamWriter(_outputPath);
            _streamWriter.AutoFlush = true;
            _csvWriter = new CsvWriter(_streamWriter, CultureInfo.InvariantCulture);
            _csvWriter.Configuration.RegisterClassMap<T2>();
            _csvWriter.WriteHeader<T1>();
            _csvWriter.NextRecord();
        }

        public void Dispose()
        {
            if (!_isEnabled)
                return;
            _streamWriter.Flush();
            _streamWriter.Dispose();
            _csvWriter.Flush();
            _csvWriter.Dispose();
        }

        public Task WriteResultAsync(T1 result)
        {
            if (!_isEnabled)
                return Task.CompletedTask;
            lock (_lockObject)
            {
                _csvWriter.WriteRecord(result);
                _csvWriter.NextRecord();
                _csvWriter.Flush();
            }
            return Task.CompletedTask;
        }
    }
}
