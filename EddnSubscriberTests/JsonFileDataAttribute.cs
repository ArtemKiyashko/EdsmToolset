using EddnSubscriber.Models;
using EddnSubscriberTests.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace EddnSubscriberTests
{
    class JsonFileDataAttribute : DataAttribute
    {
        private readonly string _filePath;
        private readonly Type _deserializeType;


        /// <summary>
        /// Load data from a JSON file as the data source for a theory
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the JSON file to load</param>
        /// /// <param name="deserializeType">Type of object in file</param>
        public JsonFileDataAttribute(string filePath, Type deserializeType)
        {
            _filePath = filePath;
            _deserializeType = deserializeType;
        }

        /// <inheritDoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

            // Get the absolute path to the JSON file
            var path = Path.IsPathRooted(_filePath)
                ? _filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            // Load the file
            var fileData = File.ReadAllText(_filePath);
            var targetType = MakeGeneric.GetEnumerable(_deserializeType);
            return (IEnumerable<object[]>)JsonConvert.DeserializeObject(fileData, targetType);
        }
    }
}
