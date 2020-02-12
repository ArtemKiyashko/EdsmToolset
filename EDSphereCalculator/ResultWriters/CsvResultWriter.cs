using CsvHelper;
using EDSphereCalculator.CalculatorModels;
using EDSphereCalculator.Mappers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator.ResultWriters
{
    public class CsvResultWriter : IResultWriter<Star>, IDisposable
    {
        private readonly CmdOptions _options;
        private readonly StreamWriter _streamWriter;
        private readonly CsvWriter _csvWriter;
        private readonly bool _isEnabled = true;
        private object _lockObject = new object();

        public CsvResultWriter(CmdOptions options)
        {
            _options = options;
            if (string.IsNullOrEmpty(_options.CsvOutputPath))
            {
                _isEnabled = false;
                return;
            }
            _streamWriter = new StreamWriter(_options.CsvOutputPath);
            _streamWriter.AutoFlush = true;
            _csvWriter = new CsvWriter(_streamWriter, CultureInfo.InvariantCulture);
            _csvWriter.Configuration.RegisterClassMap<CsvMap>();
            _csvWriter.WriteHeader<Star>();
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

        public Task WriteResultAsync(Star result)
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
