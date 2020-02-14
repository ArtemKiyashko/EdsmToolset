using AutoMapper;
using CommandLine;
using EDSphereCalculator.CalculatorModels;
using EDSphereCalculator.Extensions;
using EDSphereCalculator.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EDSphereCalculator
{
    class Program
    {
        private static Calculator _calculator;
        private static IDbImporter _dbImporter;
        private static IServiceProvider _serviceProvider;
        private static IServiceCollection _serviceCollection;
        private static IConfigurationRoot _configuration;
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
            _configuration = builder.Build();
            
            _serviceCollection = new ServiceCollection();

            Parser.Default.ParseArguments<CmdOptions>(args)
                .WithParsed(RunApplication);
            Console.WriteLine("Press any key to stop");
            Console.ReadKey();
        }

        private static async void RunApplication(CmdOptions options)
        {
            _serviceProvider = _serviceCollection
                .AddSingleton(options)
                .AddTransient<Calculator>()
                .AddDistanceResultWriters(options)
                .AddAutoMapper(typeof(MapperProfile))
                .AddTransient<IDataReader<EdSystem>>((_) => new DefaultDataReader<EdSystem>(options.EdsmStarDataPath))
                .AddTransient<IDataReader<CelestialBody>>((_) => new DefaultDataReader<CelestialBody>(options.EdsmBodiesDataPath))
                .AddDbContext<EdsmDbContext>(dbOptions =>
                {
                    dbOptions.UseLazyLoadingProxies();
                    dbOptions.UseSqlServer(_configuration.GetConnectionString("Default"));
                })
                .AddTransient<DefaultDbImporter>()
                .BuildServiceProvider();

            using var scope = _serviceProvider.CreateScope();
            _dbImporter = scope.ServiceProvider.GetService<DefaultDbImporter>();
            await _dbImporter.ImportSystemsAsync();
            //_calculator = scope.ServiceProvider.GetService<Calculator>();
            //var st = new Stopwatch();
            //st.Start();
            //await _calculator.RunProcessingAsync();
            //st.Stop();
            //var ts = st.Elapsed;
            //Console.WriteLine("Async Processing. Elapsed Time is {0:00}:{1:00}:{2:00}.{3}",
            //            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("Done");
        }
    }
}
