using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class CelestialBody : BaseModel
    {
        [JsonProperty("id")]
        public long EdsmId { get; set; }
        [JsonProperty("id64")]
        public long? EdsmId64 { get; set; }
        [JsonProperty("bodyId")]
        public int? EdsmBodyId { get; set; }
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        [Required]
        [JsonProperty("type")]
        public string Type { get; set; }
        [Required]
        [JsonProperty("subType")]
        public string SubType { get; set; }
        [JsonProperty("distanceToArrival")]
        public int DistanceToArrival { get; set; }
        [JsonProperty("isLandable")]
        public bool? IsLandable { get; set; }
        [JsonProperty("gravity")]
        public double? Gravity { get; set; }
        [JsonProperty("earthMasses")]
        public double? EarthMasses { get; set; }
        [JsonProperty("radius")]
        public double? Radius { get; set; }
        [JsonProperty("surfaceTemperature")]
        public int? SurfaceTemperature { get; set; }
        [JsonProperty("surfacePressure")]
        public double? SurfacePressure { get; set; }
        [JsonProperty("volcanismType")]
        public string VolcanismType { get; set; }
        [JsonProperty("atmosphereType")]
        public string AtmosphereType { get; set; }
        [JsonProperty("terraformingState")]
        public string TerraformingState { get; set; }
        [JsonProperty("orbitalPeriod")]
        public double? OrbitalPeriod { get; set; }
        [JsonProperty("semiMajorAxis")]
        public double? SemiMajorAxis { get; set; }
        [JsonProperty("orbitalEccentricity")]
        public double? OrbitalEccentricity { get; set; }
        [JsonProperty("orbitalInclination")]
        public double? OrbitalInclination { get; set; }
        [JsonProperty("argOfPeriapsis")]
        public double? ArgOfPeriapsis { get; set; }
        [JsonProperty("rotationalPeriod")]
        public double? RotationalPeriod { get; set; }
        [JsonProperty("rotationalPeriodTidallyLocked")]
        public bool RotationalPeriodTidallyLocked { get; set; }
        [JsonProperty("axialTilt")]
        public double? AxialTilt { get; set; }
        [JsonProperty("updateTime")]
        public DateTime UpdateTime { get; set; }
        [JsonProperty("systemId")]
        public long EdSystemId { get; set; }
        [JsonProperty("systemId64")]
        public long? EdSystemId64 { get; set; }
        [JsonProperty("isMainStar")]
        public bool? IsMainStar { get; set; }
        [JsonProperty("isScoopable")]
        public bool? IsScoopable { get; set; }
        [JsonProperty("age")]
        public int? Age { get; set; }
        [JsonProperty("spectralClass")]
        public string SpectralClass { get; set; }
        [JsonProperty("luminosity")]
        public string Luminosity { get; set; }
        [JsonProperty("absoluteMagnitude")]
        public double? AbsoluteMagnitude { get; set; }
        [JsonProperty("solarMasses")]
        public double? SolarMasses { get; set; }
        [JsonProperty("solarRadius")]
        public double? SolarRadius { get; set; }
        [JsonProperty("systemName")]
        public string EdSystemName { get; set; }
        [JsonProperty("reserveLevel")]
        public string ReserveLevel { get; set; }

        [JsonProperty("rings")]
        public virtual ICollection<CelestialBodyRing> Rings { get; set; }
        [JsonProperty("belts")]
        public virtual ICollection<CelestialBodyBelt> Belts { get; set; }

        [NotMapped]
        [JsonProperty("parents")]
        public ICollection<Dictionary<string, int>> Parents { get; set; }

        [NotMapped]
        [JsonProperty("atmosphereComposition")]
        public IDictionary<string, decimal> AtmosphereCompositions { get; set; }

        [NotMapped]
        [JsonProperty("solidComposition")]
        public IDictionary<string, decimal> SolidCompositions { get; set; }

        [NotMapped]
        [JsonProperty("materials")]
        public IDictionary<string, decimal> Materials { get; set; }


        [JsonIgnore]
        public virtual ICollection<CelestialBodyParent> BodyParents { get; set; }
        [JsonIgnore]
        public virtual ICollection<CelestialBodyAtmosphereComposition> BodyAtmosphereCompositions { get; set; }
        [JsonIgnore]
        public virtual ICollection<CelestialBodySolidComposition> BodySolidCompositions { get; set; }
        [JsonIgnore]
        public virtual ICollection<CelestialBodyMaterial> BodyMaterials { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual EdSystem EdSystem { get; set; }
    }
}
