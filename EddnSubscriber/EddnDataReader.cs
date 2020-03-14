using EddnSubscriber.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EddnSubscriber
{
    public class EddnDataReader : IDataReader
    {
        private readonly JsonSerializer _serializer;
        private readonly ILogger<EddnDataReader> _logger;
        private readonly IList<string> _deserializationErrors;

        public EddnDataReader(ILogger<EddnDataReader> logger)
        {
            _serializer = new JsonSerializer();
            _serializer.Error += _serializer_Error;
            _serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            _serializer.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
            _deserializationErrors = new List<string>();
            _logger = logger;
        }

        private void _serializer_Error(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
        {
            _logger.LogError(e.ErrorContext.Error, e.ErrorContext.Error.Message);
            _deserializationErrors.Add(e.ErrorContext.Error.Message);
            e.ErrorContext.Handled = true;
        }

        public T Read<T>(string entity)
        {
            using var stringReader = new StringReader(entity);
            using var jsonReader = new JsonTextReader(stringReader);
            return _serializer.Deserialize<T>(jsonReader);
        }
    }
}
