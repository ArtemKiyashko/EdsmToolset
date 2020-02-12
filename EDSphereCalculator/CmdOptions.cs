using CommandLine;
using EDSphereCalculator.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator
{
    public class CmdOptions
    {
        [Option('d', "data", Required = true, HelpText = "Set path to EDSM night dump file woth stars and coordinates")]
        public string EdsmDataPath { get; set; }

        [Option('x', Default = 0, HelpText = "Set X coordinate of starting system")]
        public double X { get; set; }

        [Option('y', Default = 0, HelpText = "Set Y coordinate of starting system")]
        public double Y { get; set; }

        [Option('z', Default = 0, HelpText = "Set Z coordinate of starting system")]
        public double Z { get; set; }

        [Option("maxDist", Required = true, HelpText = "Set maximum sphere radius for search in LY")]
        public double MaximumDistance { get; set; }

        [Option("minDist", Required = true, HelpText = "Set minimum sphere radius for search in LY")]
        public double MinimumDistance { get; set; }

        [Option("csv", Required = false, HelpText = "Set output path and filename for result CSV")]
        public string CsvOutputPath { get; set; }
    }
}
