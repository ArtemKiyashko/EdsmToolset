using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdsmDbImporter
{
    public class DbImporterHostedService : IHostedService
    {
        private readonly IDbImporter _dbImporter;
        private readonly ILogger<DbImporterHostedService> _logger;

        public DbImporterHostedService(IDbImporter dbImporter, ILogger<DbImporterHostedService> logger)
        {
            _dbImporter = dbImporter;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting batch import service");
            var st = new Stopwatch();
            st.Start();
            await _dbImporter.ImportSystemsAsync();
            st.Stop();
            var ts = st.Elapsed;
            _logger.LogInformation("Import EdSystems. Elapsed Time is {0:00}:{1:00}:{2:00}.{3}",
                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            st.Restart();
            await _dbImporter.ImportBodiesAsync();
            st.Stop();
            ts = st.Elapsed;
            _logger.LogInformation("Import Celestial Bodies. Elapsed Time is {0:00}:{1:00}:{2:00}.{3}",
                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping batch import service");
            return Task.CompletedTask;
        }
    }
}
