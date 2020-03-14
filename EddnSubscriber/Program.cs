using AutoMapper;
using EddnSubscriber.Mappers;
using EddnSubscriber.Models;
using EdsmDbImporter;
using Ionic.Zlib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EddnSubscriber
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, appConfig) =>
                {
                    appConfig.AddJsonFile("subscribersettings.json", optional: false, reloadOnChange: true);
                    appConfig.AddEnvironmentVariables();
                })
                .ConfigureServices((hostContext, services) => {
                    services.AddOptions();
                    services.AddHostedService<EddnSubscriberService>();
                    services.Configure<EddnSettings>(hostContext.Configuration.GetSection("EddnSettings"));
                    services.AddTransient<IDataReader, EddnDataReader>();
                    services.AddTransient<IDbImporter, DefaultDbImporter>();
                    services.AddTransient<IImportTargetFactory, EddnImportTargetFactory>();
                    services.AddDbContext<EdsmDbContext>(dbOptions =>
                    {
                        dbOptions.UseLazyLoadingProxies();
                        dbOptions.UseNpgsql(hostContext.Configuration.GetConnectionString("Default"), sqlOptions => sqlOptions.CommandTimeout(1800));
                    });
                    services.AddAutoMapper(typeof(MapperProfile));
                })
                .ConfigureLogging(logConfig =>
                {
                    logConfig.AddConsole();
                })
                .Build();
            await host.RunAsync();
        }
    }
}
