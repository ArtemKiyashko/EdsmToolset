using CommandLine;
using EDSphereCalculator.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator
{
    public enum ActionTypes
    {
        Merge,
        Insert
    }
    public class CmdOptions
    {
        [Option('a', "action", Required = true, HelpText = "Action: merge or insert")]
        public ActionTypes Action { get; set; }

        [Option('s', "systemsWithCoordinates", Required = false, HelpText = "Set path to EDSM night dump file wih stars and coordinates")]
        public string EdsmStarDataPath { get; set; }

        [Option("skipSystems", Required = false, Default = 0, HelpText = "Number of entries to skip at the beggining of the file")]
        public long SkipSystems { get; set; }

        [Option('b', "bodies", Required = false, HelpText = "Set path to EDSM night dump file celestial bodies information")]
        public string EdsmBodiesDataPath { get; set; }

        [Option("skipBodies", Required = false, Default = 0, HelpText = "Number of entries to skip at the beggining of the file")]
        public long SkipBodies { get; set; }

        [Option('x', Default = 0, HelpText = "Set X coordinate of starting system")]
        public double X { get; set; }

        [Option('y', Default = 0, HelpText = "Set Y coordinate of starting system")]
        public double Y { get; set; }

        [Option('z', Default = 0, HelpText = "Set Z coordinate of starting system")]
        public double Z { get; set; }

        [Option("startSystemName", Required = false, HelpText = "Set start system name. That name will be used only in report. Calculation will be done based on coordinates")]
        public string StartSystemName { get; set; }

        [Option("maxDist", Default = 100, HelpText = "Set maximum sphere radius for search in LY")]
        public double MaximumDistance { get; set; }

        [Option("minDist", Default = 90, HelpText = "Set minimum sphere radius for search in LY")]
        public double MinimumDistance { get; set; }

        [Option("csvDistance", Required = false, HelpText = "Set output path and filename for result CSV with distance report")]
        public string CsvDistanceOutputPath { get; set; }

        [Option("maxSystemsBatch", Default = 100000, HelpText = "Set maximum batch size for EdSystems import")]
        public int MaxSystemsBatch { get; set; }

        [Option("maxBodiesBatch", Default = 10000, HelpText = "Set maximum batch size for CelestialBodies import")]
        public int MaxBodiesBatch { get; set; }
    }
}
