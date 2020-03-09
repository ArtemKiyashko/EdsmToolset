using AutoMapper;
using DataModels;
using EddnSubscriber.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Mappers
{
    public class EddnToEdsmBelt : ITypeConverter<EddnCelestialBodyRing, CelestialBodyBelt>
    {
        public CelestialBodyBelt Convert(EddnCelestialBodyRing source, CelestialBodyBelt destination, ResolutionContext context)
        {
            destination = new CelestialBodyBelt();
            destination.InnerRadius = source.InnerRad;
            destination.Mass = source.MassMT;
            destination.Name = source.Name;
            destination.OuterRadius = source.OuterRad;
            destination.Type = source.RingClass;
            return destination;
        }
    }
}
