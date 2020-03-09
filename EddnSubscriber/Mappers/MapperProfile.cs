using AutoMapper;
using DataModels;
using EddnSubscriber.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EddnCelestialBody, CelestialBody>().ConvertUsing<EddnToEdsmCelestialBody>();
            CreateMap<EddnCelestialBodyRing, CelestialBodyRing>().ConvertUsing<EddnToEdsmRing>();
            CreateMap<EddnCelestialBodyRing, CelestialBodyBelt>().ConvertUsing<EddnToEdsmBelt>();
        }
    }
}
