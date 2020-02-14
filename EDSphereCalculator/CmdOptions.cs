using CommandLine;
using EDSphereCalculator.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator
{
    public class CmdOptions
    {
        [Option('s', "systemsWithCoordinates", Required = true, HelpText = "Set path to EDSM night dump file wih stars and coordinates")]
        public string EdsmStarDataPath { get; set; }

        [Option('b', "bodies", Required = false, HelpText = "Set path to EDSM night dump file celestial bodies information")]
        public string EdsmBodiesDataPath { get; set; }

        [Option('x', Default = 0, HelpText = "Set X coordinate of starting system")]
        public double X { get; set; }

        [Option('y', Default = 0, HelpText = "Set Y coordinate of starting system")]
        public double Y { get; set; }

        [Option('z', Default = 0, HelpText = "Set Z coordinate of starting system")]
        public double Z { get; set; }

        [Option("startSystemName", Required = false, HelpText = "Set start system name. That name will be used only in report. Calculation will be done based on coordinates")]
        public string StartSystemName { get; set; }

        [Option("maxDist", Required = true, HelpText = "Set maximum sphere radius for search in LY")]
        public double MaximumDistance { get; set; }

        [Option("minDist", Required = true, HelpText = "Set minimum sphere radius for search in LY")]
        public double MinimumDistance { get; set; }

        [Option("csvDistance", Required = false, HelpText = "Set output path and filename for result CSV with distance report")]
        public string CsvDistanceOutputPath { get; set; }
    }
}
