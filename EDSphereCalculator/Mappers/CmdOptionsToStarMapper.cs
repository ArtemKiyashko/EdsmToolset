using AutoMapper;
using EDSphereCalculator.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.Mappers
{
    public class CmdOptionsToStarMapper : ITypeConverter<CmdOptions, Star>
    {
        public Star Convert(CmdOptions source, Star destination, ResolutionContext context)
        {
            destination = new Star();
            destination.Coordinates = new StarCoordinates
            {
                X = source.X,
                Y = source.Y,
                Z = source.Z
            };
            return destination;
        }
    }
}
