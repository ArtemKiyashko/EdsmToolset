using AutoMapper;
using EDSphereCalculator.CalculatorModels;
using EDSphereCalculator.ResultWriters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator
{
    public class Calculator
    {
        private readonly CmdOptions _options;
        private readonly IResultWriterProxy<Distance> _resultWriterProxy;
        private readonly IMapper _mapper;
        private readonly IDataReader<EdSystem> _dataReader;

        public Calculator(CmdOptions options,
            IResultWriterProxy<Distance> resultWriterProxy,
            IMapper mapper,
            IDataReader<EdSystem> dataReader)
        {
            _options = options;
            _resultWriterProxy = resultWriterProxy;
            _mapper = mapper;
            _dataReader = dataReader;
        }

        public Distance CalculateDistance(EdSystem from, EdSystem to)
        {
            var distance = Math.Sqrt(
                Math.Pow((to.Coordinates.X - from.Coordinates.X), 2)
                    + Math.Pow((to.Coordinates.Y - from.Coordinates.Y), 2)
                    + Math.Pow((to.Coordinates.Z - from.Coordinates.Z), 2)
                );
            return new Distance
            {
                DistanceFrom = from,
                DistanceTo = to,
                LightYears = distance
            };
        }

        public async Task RunProcessingAsync()
        {
            var initialStar = _mapper.Map<EdSystem>(_options);
            while (await _dataReader.ReadAsync())
            {
                var distance = CalculateDistance(initialStar, _dataReader.Result);
                if (distance.LightYears >= _options.MinimumDistance && distance.LightYears <= _options.MaximumDistance)
                    await _resultWriterProxy.WriteResultAsync(distance);
            }
        }
    }
}
