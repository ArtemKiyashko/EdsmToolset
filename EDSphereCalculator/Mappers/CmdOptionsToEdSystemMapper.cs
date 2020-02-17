﻿using AutoMapper;
using EDSphereCalculator.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.Mappers
{
    public class CmdOptionsToEdSystemMapper : ITypeConverter<CmdOptions, EdSystem>
    {
        public EdSystem Convert(CmdOptions source, EdSystem destination, ResolutionContext context)
        {
            destination = new EdSystem();
            destination.Name = source.StartSystemName;
            destination.Coordinates = new EdSystemCoordinates
            {
                X = source.X,
                Y = source.Y,
                Z = source.Z
            };
            return destination;
        }
    }
}