using AutoMapper;
using DataModels;
using EddnSubscriber.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Mappers
{
    public class EddnToEdsmRing : ITypeConverter<EddnCelestialBodyRing, CelestialBodyRing>
    {
        public CelestialBodyRing Convert(EddnCelestialBodyRing source, CelestialBodyRing destination, ResolutionContext context)
        {
            destination = new CelestialBodyRing();
            destination.InnerRadius = source.InnerRad;
            destination.Mass = source.MassMT;
            destination.Name = source.Name;
            destination.OuterRadius = source.OuterRad;
            destination.Type = source.RingClass;
            return destination;
        }
    }
}
