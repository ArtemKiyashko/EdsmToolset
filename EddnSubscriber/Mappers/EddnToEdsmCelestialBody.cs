using AutoMapper;
using DataModels;
using EddnSubscriber.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Mappers
{
    public class EddnToEdsmCelestialBody : ITypeConverter<EddnCelestialBody, CelestialBody>
    {
        public CelestialBody Convert(EddnCelestialBody source, CelestialBody destination, ResolutionContext context)
        {
            destination = new CelestialBody();
            destination.EdsmBodyId = source.BodyID;
            destination.EdSystemId64 = source.SystemAddress;
            return destination;
        }
    }
}
