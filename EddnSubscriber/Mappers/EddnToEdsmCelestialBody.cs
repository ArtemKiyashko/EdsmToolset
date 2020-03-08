using AutoMapper;
using DataModels;
using EddnSubscriber.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Mappers
{
    public class EddnToEdsmCelestialBody : ITypeConverter<EddnCelestialBody, CelestialBody>
    {
        private readonly ILogger<EddnToEdsmCelestialBody> _logger;

        public EddnToEdsmCelestialBody(ILogger<EddnToEdsmCelestialBody> logger)
        {
            _logger = logger;
        }

        public CelestialBody Convert(EddnCelestialBody source, CelestialBody destination, ResolutionContext context)
        {
            destination = new CelestialBody();

            var isStar = (source.Event == EddnEvent.Scan && !string.IsNullOrEmpty(source.Luminosity))
                || source.BodyType == EddnBodyType.Star;
            
            destination.AbsoluteMagnitude = source.AbsoluteMagnitude;
            destination.Age = source.AgeMy;
            destination.ArgOfPeriapsis = source.Periapsis;
            destination.AtmosphereType = source.Atmosphere;
            destination.AxialTilt = source.AxialTilt;
            destination.DistanceToArrival = (int?)source.DistanceFromArrivalLs;
            destination.EarthMasses = source.MassEm;
            destination.EdsmBodyId = source.BodyID;
            destination.EdsmId = -1; //TODO: re-think merging strategy as we don`t have EdsmId here
            destination.EdsmId64 = source.SystemAddress; //TODO: EdsmId64 - should calculate
            destination.EdSystemId = -1;
            destination.EdSystemId64 = source.SystemAddress;
            destination.EdSystemName = source.StarSystem;
            destination.Gravity = source.SurfaceGravity;
            destination.IsLandable = !isStar ? source.Landable : null;
            destination.IsMainStar = isStar ? source.BodyID == 0 : (bool?)null;
            destination.IsScoopable = isStar ? Conststants.ScoopableStarTypes.Contains(source.StarType) : (bool?)null;
            destination.Luminosity = source.Luminosity;
            destination.Name = source.BodyName;
            destination.OrbitalEccentricity = source.Eccentricity;
            destination.OrbitalInclination = source.OrbitalInclination;
            destination.OrbitalPeriod = source.OrbitalPeriod / Conststants.PERIOD_DAYS;
            destination.Radius = !isStar ? source.Radius / 1000.0 : null;
            //destination.ReserveLevel //TODO: ReserveLevel - dont know what is this
            destination.RotationalPeriod = source.RotationPeriod / Conststants.PERIOD_DAYS;
            destination.RotationalPeriodTidallyLocked = source.TidalLock;
            destination.SemiMajorAxis = source.SemiMajorAxis / Conststants.AU_M;
            destination.SolarMasses = source.StellarMass;
            destination.SolarRadius = isStar ? source.Radius / Conststants.SOLAR_RADIUS_METERS : null;
            destination.SpectralClass = !isStar ? null : $"{source.StarType}{source.SubClass} {source.Luminosity}";
            FillSubType(source, destination, isStar);
            destination.SurfacePressure = source.SurfacePressure / Conststants.PRESSURE_PA;
            destination.SurfaceTemperature = source.SurfaceTemperature;
            destination.TerraformingState = source.TerraformState.Equals("Terraformable", StringComparison.InvariantCultureIgnoreCase) ?
                "Candidate for terraforming" :
                source.TerraformState;
            destination.Type = isStar ? "Star" : "Planet";
            destination.UpdateTime = DateTime.Now;
            destination.VolcanismType = !isStar && string.IsNullOrEmpty(source.Volcanism) ? "No volcanism" : source.Volcanism;
            return destination;
        }

        private void FillSubType(EddnCelestialBody source, CelestialBody destination, bool isStar)
        {
            if (isStar)
            {
                if (Conststants.StarNames2Edsm.TryGetValue(source.StarType, out var edsmStarType))
                    destination.SubType = edsmStarType;
                else
                {
                    destination.SubType = source.StarType;
                    _logger.LogError($"Star type [{source.StarType}] not mapped! BodyName: [{source.BodyName}]");
                }
            }
            else
            {
                if (Conststants.PlanetNames2Edsm.TryGetValue(source.PlanetClass, out var edsmPlanetType))
                    destination.SubType = edsmPlanetType;
                else
                {
                    destination.SubType = source.PlanetClass;
                    _logger.LogError($"Planet type [{source.PlanetClass}] not mapped! BodyName: [{source.BodyName}]");
                }
            }
        }
    }
}
