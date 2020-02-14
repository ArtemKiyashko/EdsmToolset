using EDSphereCalculator.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.Mappers
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<CmdOptions, EdSystem>().ConvertUsing<CmdOptionsToEdSystemMapper>();
        }
    }
}
