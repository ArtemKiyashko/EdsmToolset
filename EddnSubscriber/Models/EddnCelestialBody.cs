using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EddnSubscriber.Models
{
    public class EddnCelestialBody : EntityMessageBase
    {
        [JsonProperty("AbsoluteMagnitude")]
        public double? AbsoluteMagnitude { get; set; }
        [JsonProperty("Age_MY")]
        public int? AgeMy { get; set; }
        [JsonProperty("Atmosphere")]
        public string Atmosphere { get; set; }
        [JsonProperty("AtmosphereComposition")]
        public IEnumerable<EddnComposition> AtmosphereComposition { get; set; }
        [JsonProperty("AtmosphereType")]
        public string AtmosphereType { get; set; }
        [JsonProperty("AxialTilt")]
        public double? AxialTilt { get; set; }
        [JsonProperty("BodyID")]
        public int? BodyID { get; set; }
        [JsonProperty("BodyName")]
        public string BodyName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [DefaultValue(EddnBodyType.Unknown)]
        [JsonProperty("BodyType")]
        public EddnBodyType BodyType { get; set; }
        [JsonProperty("Composition")]
        public IDictionary<string, decimal> Composition { get; set; }
        [JsonProperty("DistanceFromArrivalLS")]
        public double? DistanceFromArrivalLs { get; set; }
        [JsonProperty("Eccentricity")]
        public double? Eccentricity { get; set; }
        [JsonProperty("Landable")]
        public bool? Landable { get; set; }
        [JsonProperty("Luminosity")]
        public string Luminosity { get; set; }
        [JsonProperty("MassEM")]
        public double? MassEm { get; set; }
        [JsonProperty("OrbitalInclination")]
        public double? OrbitalInclination { get; set; }
        [JsonProperty("OrbitalPeriod")]
        public double? OrbitalPeriod { get; set; }
        [JsonProperty("Parents")]
        public ICollection<Dictionary<string, int>> Parents { get; set; }
        [JsonProperty("Periapsis")]
        public double? Periapsis { get; set; }
        [JsonProperty("PlanetClass")]
        public string PlanetClass { get; set; }
        [JsonProperty("Radius")]
        public double? Radius { get; set; }
        [JsonProperty("Rings")]
        public IEnumerable<EddnCelestialBodyRing> Rings { get; set; }
        [JsonProperty("RotationPeriod")]
        public double? RotationPeriod { get; set; }
        [JsonProperty("ScanType")]
        public string ScanType { get; set; }
        [JsonProperty("SemiMajorAxis")]
        public double? SemiMajorAxis { get; set; }
        [JsonProperty("StarPos")]
        public IEnumerable<double> StarPos { get; set; }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }
        [JsonProperty("StarType")]
        public string StarType { get; set; }
        [JsonProperty("StellarMass")]
        public double? StellarMass { get; set; }
        [JsonProperty("Subclass")]
        public byte? SubClass { get; set; }
        [JsonProperty("SurfaceGravity")]
        public double? SurfaceGravity { get; set; }
        [JsonProperty("SurfacePressure")]
        public double? SurfacePressure { get; set; }
        [JsonProperty("SurfaceTemperature")]
        public double? SurfaceTemperature { get; set; }
        [JsonProperty("SystemAddress")]
        public long? SystemAddress { get; set; }
        [JsonProperty("TerraformState")]
        public string TerraformState { get; set; }
        [JsonProperty("TidalLock")]
        public bool? TidalLock { get; set; }
        [JsonProperty("Volcanism")]
        public string Volcanism { get; set; }
        [JsonProperty("WasDiscovered")]
        public bool? WasDiscovered { get; set; }
        [JsonProperty("WasMapped")]
        public bool? WasMapped { get; set; }
    }
}
