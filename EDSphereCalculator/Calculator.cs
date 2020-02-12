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

        public Calculator(CmdOptions options, IResultWriterProxy<Star> resultWriterProxy, IMapper mapper)
        {
            _options = options;
            _resultWriterProxy = resultWriterProxy;
            _mapper = mapper;
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

        public IEnumerable<Star> RunProcessingParallel()
        {
            var initialStar = _mapper.Map<Star>(_options);
            var result = new BlockingCollection<Star>();
            Parallel.ForEach(File.ReadLines(_options.EdsmDataPath), async (line) => {
                using(var stReader = new StringReader(line))
                using (var reader = new JsonTextReader(stReader))
                {
                    reader.SupportMultipleContent = true;
                    var serializer = new JsonSerializer();
                    while (await reader.ReadAsync())
                    {
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            var currentStar = serializer.Deserialize<Star>(reader);
                            CalculateDistance(initialStar, currentStar);
                            if (currentStar.Distance >= _options.MinimumDistance && currentStar.Distance <= _options.MaximumDistance)
                            {
                                await _resultWriterProxy.WriteResultAsync(currentStar);
                                result.Add(currentStar);
                            }
                        }
                    }
                }
            });

            return result;
        }

        public async Task<IEnumerable<Star>> RunProcessingAsync()
        {
            var initialStar = _mapper.Map<Star>(_options);
            var result = new List<Star>();
            using (var stream = new StreamReader(_options.EdsmDataPath))
            using (var reader = new JsonTextReader(stream))
            {
                reader.SupportMultipleContent = true;
                var serializer = new JsonSerializer();

                while (await reader.ReadAsync())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        var currentStar = serializer.Deserialize<Star>(reader);
                        CalculateDistance(initialStar, currentStar);
                        if (currentStar.Distance >= _options.MinimumDistance && currentStar.Distance <= _options.MaximumDistance)
                        {
                            await _resultWriterProxy.WriteResultAsync(currentStar);
                            result.Add(currentStar);
                        }
                    }
                }
            }
            return result;
        }
    }
}
