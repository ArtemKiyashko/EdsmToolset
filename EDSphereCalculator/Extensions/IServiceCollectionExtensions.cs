using EDSphereCalculator.CalculatorModels;
using EDSphereCalculator.Mappers;
using EDSphereCalculator.ResultWriters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDistanceResultWriters(this IServiceCollection services, CmdOptions options)
        {
            services.AddTransient<IResultWriter<Distance>>(_ => new CsvResultWriter<Distance, CsvMapDistance>(options.CsvDistanceOutputPath));
            services.AddTransient<IResultWriter<Distance>, ConsoleDistanceWriter>();
            services.AddTransient<IResultWriterProxy<Distance>, DefaultResultWriterProxy<Distance>>();
            return services;
        }
    }
}
