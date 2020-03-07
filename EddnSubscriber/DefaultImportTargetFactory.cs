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
    public class DefaultImportTargetFactory : IImportTargetFactory
    {
        private readonly IDbImporter _dbImporter;
        private readonly ILogger<DefaultImportTargetFactory> _logger;
        private readonly IDataReader _dataReader;
        private readonly IMapper _mapper;

        public DefaultImportTargetFactory(
            IDbImporter dbImporter, 
            ILogger<DefaultImportTargetFactory> logger, 
            IDataReader dataReader,
            IMapper mapper)
        {
            _dbImporter = dbImporter;
            _logger = logger;
            _dataReader = dataReader;
            _mapper = mapper;
        }

        public Task ImportAsync(string entity)
        {
            var baseEntity = _dataReader.Read<Entity<EntityMessageBase>>(entity);
            if (!Conststants.ValidRefs.Contains(baseEntity.Reference))
                return Task.CompletedTask;

            switch (baseEntity.Message.Event)
            {
                case EddnEvent.FSDJump:
                    var eddnSystem = _dataReader.Read<Entity<EddnSystem>>(entity);
                    var edsmSystem = _mapper.Map<EdSystem>(eddnSystem);
                    return _dbImporter.ImportSystemAsync(edsmSystem);

                case EddnEvent.Scan:
                case EddnEvent.Location:
                    var eddnBody = _dataReader.Read<Entity<EddnCelestialBody>>(entity);
                    var edsmBody = _mapper.Map<CelestialBody>(eddnBody);
                    return _dbImporter.ImportBodyAsync(edsmBody);
                
                default:
                    return Task.CompletedTask;
            }
        }
    }
}
