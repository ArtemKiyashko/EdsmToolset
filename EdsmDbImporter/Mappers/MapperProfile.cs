using EdsmDbImporter.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdsmDbImporter.Mappers
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<CmdOptions, EdSystem>().ConvertUsing<CmdOptionsToEdSystemMapper>();
        }
    }
}
