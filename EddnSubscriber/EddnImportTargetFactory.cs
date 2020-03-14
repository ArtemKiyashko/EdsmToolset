using AutoMapper;
using DataModels;
using EddnSubscriber.Models;
using EdsmDbImporter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EddnSubscriber
{
    public class EddnImportTargetFactory : IImportTargetFactory
    {
        private readonly IDbImporter _dbImporter;
        private readonly ILogger<EddnImportTargetFactory> _logger;
        private readonly IDataReader _dataReader;
        private readonly IMapper _mapper;

        public EddnImportTargetFactory(
            IDbImporter dbImporter, 
            ILogger<EddnImportTargetFactory> logger, 
            IDataReader dataReader,
            IMapper mapper)
        {
            _dbImporter = dbImporter;
            _logger = logger;
            _dataReader = dataReader;
            _mapper = mapper;
        }

        public async Task ImportAsync(string entity)
        {
            var baseEntity = _dataReader.Read<Entity<EntityMessageBase>>(entity);
            if (!Conststants.ValidRefs.Contains(baseEntity.Reference))
                return;

            switch (baseEntity.Message.Event)
            {
                case EddnEvent.FSDJump:
                    var eddnSystem = _dataReader.Read<Entity<EddnSystem>>(entity);
                    var edsmSystem = _mapper.Map<EdSystem>(eddnSystem.Message);
                    await _dbImporter.ImportSystemAsync(edsmSystem);
                    break;

                case EddnEvent.Scan:
                case EddnEvent.Location:
                    var eddnBody = _dataReader.Read<Entity<EddnCelestialBody>>(entity);
                    var edsmBody = _mapper.Map<CelestialBody>(eddnBody.Message);
                    await _dbImporter.ImportBodyAsync(edsmBody);
                    break;
            }
        }
    }
}
