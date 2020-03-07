using AutoMapper;
using CommandLine;
using DataModels;
using EdsmDbImporter.Extensions;
using EdsmDbImporter.Mappers;
using EdsmDbImporter.ResultWriters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EdsmDbImporter
{
    static class Program
    {
        private static ParserResult<CmdOptions> _parserResult;
        private static IConfiguration _configuration;
        static async Task Main(string[] args)
        {
            var parser = new Parser(with =>
            {
                with.CaseInsensitiveEnumValues = true;
                with.HelpWriter = Console.Error;
            });
            _parserResult = parser.ParseArguments<CmdOptions>(args).WithNotParsed(_ => Environment.Exit(-1));

            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return new HostBuilder()
                .ConfigureAppConfiguration((appConfig) => appConfig.AddConfiguration(_configuration))
                .ConfigureServices((hostContext, services) =>
                {
                    _parserResult.WithParsed(cmdOptions => services.AddSingleton(cmdOptions));
                    services.AddOptions();
                    services.AddHostedService<DbImporterHostedService>();
                    services.AddTransient<IDataReader<EdSystem>>((_) => new DefaultDataReader<EdSystem>(
                        _.GetService<CmdOptions>().EdsmStarDataPath,
                        _.GetService<ILogger<DefaultDataReader<EdSystem>>>(),
                        _.GetService<CmdOptions>().SkipSystems));
                    services.AddTransient<IDataReader<CelestialBody>>((_) => new DefaultDataReader<CelestialBody>(
                        _.GetService<CmdOptions>().EdsmBodiesDataPath,
                        _.GetService<ILogger<DefaultDataReader<CelestialBody>>>(),
                        _.GetService<CmdOptions>().SkipBodies));
                    services.AddDbContext<EdsmDbContext>(dbOptions =>
                    {
                        dbOptions.UseLazyLoadingProxies();
                        dbOptions.UseNpgsql(hostContext.Configuration.GetConnectionString("Postgre"), sqlOptions => sqlOptions.CommandTimeout(1800));
                    });
                    services.AddTransient<IDbImporter, DefaultDbImporter>();
                    services.AddTransient<IImportActionFactory, DefaultImportActionFactory>();
                })
                .ConfigureLogging((hostContext, logConfig) =>
                {
                    logConfig
                        .AddFilter("Microsoft", LogLevel.Error)
                        .AddConsole();
                });
        }
    }
}
