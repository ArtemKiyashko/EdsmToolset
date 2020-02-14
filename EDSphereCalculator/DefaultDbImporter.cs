using EDSphereCalculator.CalculatorModels;
using EDSphereCalculator.Extensions;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator
{
    public class DefaultDbImporter : IDbImporter
    {
        private readonly IDataReader<CelestialBody> _bodyDataReader;
        private readonly EdsmDbContext _dbContext;
        private readonly IDataReader<EdSystem> _edSystemDataReader;

        public DefaultDbImporter(IDataReader<CelestialBody> bodyDataReader,
            IDataReader<EdSystem> edSystemDataReader,
            EdsmDbContext dbContext)
        {
            _bodyDataReader = bodyDataReader;
            _dbContext = dbContext;
            _edSystemDataReader = edSystemDataReader;
        }

        public async Task ImportSystemsAsync()
        {
            var entities = new List<EdSystem>();
            while (await _edSystemDataReader.ReadAsync())
            {
                entities.Add(_edSystemDataReader.Result);
                if (entities.Count >= 1000)
                {
                    await _dbContext.BulkInsertAsync(entities);
                    entities.Clear();
                }
            }
            await _dbContext.BulkInsertAsync(entities);
        }
        public async Task ImportBodiesAsync()
        {
            var entities = new List<CelestialBody>();
            while (await _bodyDataReader.ReadAsync())
            {
                entities.Add(_bodyDataReader.Result.AdaptToDb());
                if (entities.Count >= 1000)
                {
                    await _dbContext.BulkInsertAsync(entities);
                    entities.Clear();
                }
            }
            await _dbContext.BulkInsertAsync(entities);
        }
    }
}
