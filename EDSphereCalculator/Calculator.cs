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
        private readonly IResultWriterProxy<Star> _resultWriterProxy;
        private readonly IMapper _mapper;
        private readonly IDataReader<Star> _dataReader;

        public Calculator(CmdOptions options,
            IResultWriterProxy<Star> resultWriterProxy,
            IMapper mapper,
            IDataReader<Star> dataReader)
        {
            _options = options;
            _resultWriterProxy = resultWriterProxy;
            _mapper = mapper;
            _dataReader = dataReader;
        }

        public void CalculateDistance(Star from, Star to)
        {
            var distance = Math.Sqrt(
                Math.Pow((to.Coordinates.X - from.Coordinates.X), 2)
                    + Math.Pow((to.Coordinates.Y - from.Coordinates.Y), 2)
                    + Math.Pow((to.Coordinates.Z - from.Coordinates.Z), 2)
                );
            to.DistanceFrom = from;
            to.Distance = distance;
            from.DistanceFrom = to;
            from.Distance = distance;
        }

        public async Task RunProcessingAsync()
        {
            var initialStar = _mapper.Map<Star>(_options);
            while (await _dataReader.ReadAsync())
            {
                CalculateDistance(initialStar, _dataReader.Result);
                if (_dataReader.Result.Distance >= _options.MinimumDistance && _dataReader.Result.Distance <= _options.MaximumDistance)
                    await _resultWriterProxy.WriteResultAsync(_dataReader.Result);
            }
        }
    }
}
