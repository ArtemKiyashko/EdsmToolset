using AutoMapper;
using DataModels;
using EddnSubscriber.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Mappers
{
    public class EddnToEdsmSystem : ITypeConverter<EddnSystem, EdSystem>
    {
        public EdSystem Convert(EddnSystem source, EdSystem destination, ResolutionContext context)
        {
            destination = new EdSystem
            {
                EdsmId = -1,
                EdsmId64 = source.SystemAddress,
                Name = source.StarSystem,
                Date = DateTime.UtcNow
            };
            var arrayCoordinates = (List<double>)source.StarPos;
            destination.Coordinates = new EdSystemCoordinates
            {
                X = arrayCoordinates[0],
                Y = arrayCoordinates[1],
                Z = arrayCoordinates[2]
            };
            return destination;
        }
    }
}
