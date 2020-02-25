using CommandLine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdsmDbImporter
{
    public class EdsmDbContextFactory : IDesignTimeDbContextFactory<EdsmDbContext>
    {
        public EdsmDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EdsmDbContext>();
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString("Postgre"), sqlOptions => sqlOptions.CommandTimeout(1800));

            return new EdsmDbContext(optionsBuilder.Options);
        }
    }
}
