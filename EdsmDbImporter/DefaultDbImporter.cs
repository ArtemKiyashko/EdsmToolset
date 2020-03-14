using DataModels;
using DataModels.Extensions;
using EdsmDbImporter.Extensions;
using EdsmDbImporter.ResultWriters;
using EFCore.BulkExtensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace EdsmDbImporter
{
    public class DefaultDbImporter : IDbImporter
    {
        private readonly IDataReader<CelestialBody> _bodyDataReader;
        private readonly EdsmDbContext _dbContext;
        private readonly IDataReader<EdSystem> _edSystemDataReader;
        private readonly CmdOptions _cmdOptions;
        private readonly IImportActionFactory _importActionFactory;
        private readonly ILogger<DefaultDbImporter> _logger;

        public DefaultDbImporter(
            IDataReader<CelestialBody> bodyDataReader,
            IDataReader<EdSystem> edSystemDataReader,
            EdsmDbContext dbContext,
            ILogger<DefaultDbImporter> logger,
            CmdOptions cmdOptions,
            IImportActionFactory importActionFactory)
        {
            _bodyDataReader = bodyDataReader;
            _dbContext = dbContext;
            _edSystemDataReader = edSystemDataReader;
            _cmdOptions = cmdOptions;
            _importActionFactory = importActionFactory;
            _logger = logger;
        }

        public DefaultDbImporter(
            EdsmDbContext dbContext,
            ILogger<DefaultDbImporter> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task ImportSystemsAsync()
        {
            _logger.LogInformation($"Systems to skip: {_cmdOptions.SkipSystems}");
            var entities = new List<EdSystem>();
            long entitiesProcessed = 0;
            while (await _edSystemDataReader.ReadAsync())
            {
                entities.Add(_edSystemDataReader.Result);
                if (entities.Count >= _cmdOptions.MaxSystemsBatch)
                {
                    await _importActionFactory.ImportAsync(_dbContext, entities, BulkOptions<EdSystem>(EdSystemPrimaryKeyMapping));
                    entitiesProcessed += entities.Count;
                    _logger.LogInformation($"Systems processed: {entitiesProcessed}");
                    entities.Clear();
                }
            }
            await _importActionFactory.ImportAsync(_dbContext, entities, BulkOptions<EdSystem>(EdSystemPrimaryKeyMapping));
            entitiesProcessed += entities.Count;
            _logger.LogInformation($"Systems processed: {entitiesProcessed}");
        }

        private Action<BulkOperation<T>> BulkOptions<T>(Action<BulkOperation> graphOperationBuilder) where T : class
        {
            return _ =>
            {
                _.IncludeGraph = true;
                _.InsertIfNotExists = true;
                _.IncludeGraphOperationBuilder = graphOperationBuilder;
            };
        }

        private void EdSystemPrimaryKeyMapping(BulkOperation operation)
        {
            if (operation is BulkOperation<EdSystem>)
            {
                var bulk = (BulkOperation<EdSystem>)operation;
                bulk.ColumnPrimaryKeyExpression = c => c.EdsmId;
            }
            if (operation is BulkOperation<EdSystemCoordinates>)
            {
                var bulk = (BulkOperation<EdSystemCoordinates>)operation;
                bulk.ColumnPrimaryKeyExpression = c => new { c.X, c.Y, c.Z };
            }
        }

        public async Task ImportBodiesAsync()
        {
            _logger.LogInformation($"Bodies to skip: {_cmdOptions.SkipBodies}");
            var entities = new List<CelestialBody>();
            long entitiesProcessed = 0;
            while (await _bodyDataReader.ReadAsync())
            {
                entities.Add(_bodyDataReader.Result.AdaptToDb());
                if (entities.Count >= _cmdOptions.MaxBodiesBatch)
                {
                    await _importActionFactory.ImportAsync(_dbContext, entities, BulkOptions<CelestialBody>(BodyPrimaryKeyMapping));
                    entitiesProcessed += entities.Count;
                    _logger.LogInformation($"Bodies processed: {entitiesProcessed}");
                    entities.Clear();
                }
            }
            await _importActionFactory.ImportAsync(_dbContext, entities, BulkOptions<CelestialBody>(BodyPrimaryKeyMapping));
            entitiesProcessed += entities.Count;
            _logger.LogInformation($"Bodies processed: {entitiesProcessed}");
        }

        private void BodyPrimaryKeyMapping(BulkOperation operation)
        {
            if (operation is BulkOperation<CelestialBody>)
            {
                var bulk = (BulkOperation<CelestialBody>)operation;
                bulk.ColumnPrimaryKeyExpression = c => c.EdsmId;
            }
            if (operation is BulkOperation<CelestialBodyAtmosphereComposition>)
            {
                var bulk = (BulkOperation<CelestialBodyAtmosphereComposition>)operation;
                bulk.ColumnPrimaryKeyExpression = c => new { c.BodyId, c.Key };
            }
            if (operation is BulkOperation<CelestialBodyBelt>)
            {
                var bulk = (BulkOperation<CelestialBodyBelt>)operation;
                bulk.ColumnPrimaryKeyExpression = c => new { c.BodyId, c.Name };
            }
            if (operation is BulkOperation<CelestialBodyMaterial>)
            {
                var bulk = (BulkOperation<CelestialBodyMaterial>)operation;
                bulk.ColumnPrimaryKeyExpression = c => new { c.BodyId, c.Key };
            }
            if (operation is BulkOperation<CelestialBodyParent>)
            {
                var bulk = (BulkOperation<CelestialBodyParent>)operation;
                bulk.ColumnPrimaryKeyExpression = c => new { c.BodyId, c.Key };
            }

            if (operation is BulkOperation<CelestialBodyRing>)
            {
                var bulk = (BulkOperation<CelestialBodyRing>)operation;
                bulk.ColumnPrimaryKeyExpression = c => new { c.BodyId, c.Name };
            }
            if (operation is BulkOperation<CelestialBodySolidComposition>)
            {
                var bulk = (BulkOperation<CelestialBodySolidComposition>)operation;
                bulk.ColumnPrimaryKeyExpression = c => new { c.BodyId, c.Key };
            }
        }

        public Task ImportBodyAsync(CelestialBody celestialBody)
        {
            return Task.CompletedTask;
        }

        public Task ImportSystemAsync(EdSystem edSystem)
        {
            return Task.CompletedTask;
        }
    }
}
