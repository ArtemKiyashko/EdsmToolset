using AutoMapper;
using CommandLine;
using EDSphereCalculator.CalculatorModels;
using EDSphereCalculator.Mappers;
using EDSphereCalculator.ResultWriters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EDSphereCalculator
{
    class Program
    {
        private static Calculator _calculator;
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CmdOptions>(args)
                .WithParsed(RunApplication);
            Console.WriteLine("Press any key to stop");
            Console.ReadKey();
        }

        private static async void RunApplication(CmdOptions options)
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton(options)
                .AddTransient<Calculator>()
                .AddTransient<IResultWriter<Star>, ConsoleWriter>()
                .AddTransient<IResultWriter<Star>, CsvResultWriter>()
                .AddTransient<IResultWriterProxy<Star>, DefaultResultWriterProxy>()
                .AddAutoMapper(typeof(MapperProfile))
                .BuildServiceProvider();

            using var scope = _serviceProvider.CreateScope();
            _calculator = scope.ServiceProvider.GetService<Calculator>();
            var st = new Stopwatch();
            st.Start();
            await _calculator.RunProcessingAsync();
            st.Stop();
            var ts = st.Elapsed;
            Console.WriteLine("Async Processing. Elapsed Time is {0:00}:{1:00}:{2:00}.{3}",
                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("Done");
        }
    }
}
