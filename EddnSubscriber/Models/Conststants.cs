using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Models
{
    public static class Conststants
    {
        public static readonly List<Uri> ValidRefs = new List<Uri> { 
            new Uri("https://eddn.edcd.io/schemas/journal/1")
        };

        public const double SOLAR_RADIUS_METERS = 695700000;
        public const double PERIOD_DAYS = 86400;
        public const double AU_M = 149597870700;
        public const double LS_M = 299792458;
        public const double PRESSURE_PA = 101325;
        public const double AU_LS_M = AU_M / LS_M;
        public const double ONE_G = 9.80665;

        public static List<string> ScoopableStarTypes = new List<string>
        {
            "O", "B", "A", "F", "G", "K", "M"
        };

        public static Dictionary<string, string> PlanetNames2Edsm = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            // EDDN name                           EDSM name                  
            { "Rocky ice body",                    "Rocky Ice world" },
            { "High metal content body" ,          "High metal content world"},
            { "Sudarsky class I gas giant",        "Class I gas giant"},
            { "Sudarsky class II gas giant",       "Class II gas giant"},
            { "Sudarsky class III gas giant",      "Class III gas giant"},
            { "Sudarsky class IV gas giant",       "Class IV gas giant"},
            { "Sudarsky class V gas giant",        "Class V gas giant"},
            { "Earthlike body",                    "Earth-like world" },
        };

        public static Dictionary<string, string> StarNames2Edsm = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            // EDDN name                EDSM name
            { "A_BlueWhiteSuperGiant",  "A (Blue-White super giant) Star" },
            { "B_BlueWhiteSuperGiant",  "B (Blue-White super giant) Star" },
            { "F_WhiteSuperGiant",      "F (White super giant) Star" },
            { "G_WhiteSuperGiant",      "G (White-Yellow super giant) Star" },
            { "G",                      "G (White-Yellow) Star" },
            { "K_OrangeGiant",          "K (Yellow-Orange giant) Star" },
            { "M_RedGiant",             "M (Red giant) Star" },
            { "M_RedSuperGiant",        "M (Red super giant) Star" },
            { "H",                      "Black Hole" },
            { "C",                      "C Star" },
            { "CJ",                     "CJ Star" },
            { "CN",                     "CN Star" },
            { "AeBe",                   "Herbig Ae/Be Star" },
            { "MS",                     "MS-type Star" },
            { "N",                      "Neutron Star" },
            { "S",                      "S-type Star" },
            { "TTS",                    "T Tauri Star" },
            { "WC",                     "Wolf-Rayet C Star" },
            { "WN",                     "Wolf-Rayet N Star" },
            { "WNC",                    "Wolf-Rayet NC Star" },
            { "WO",                     "Wolf-Rayet O Star" },
            { "W",                      "Wolf-Rayet Star" },
            { "DAZ",                    "White Dwarf (DAZ) Star" },
            { "DQ",                     "White Dwarf (DQ) Star" },
            { "DCV",                    "White Dwarf (DCV) Star" },
            { "DAV",                    "White Dwarf (DAV) Star" },
            { "DB",                     "White Dwarf (DB) Star" },
            { "DAB",                    "White Dwarf (DAB) Star" },
            { "D",                      "White Dwarf (D) Star" },
            { "DBZ",                    "White Dwarf (DBZ) Star" },
            { "DA",                     "White Dwarf (DA) Star" },
            { "DBV",                    "White Dwarf (DBV) Star" },
        };
    }
}
