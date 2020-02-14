using EDSphereCalculator.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.Extensions
{
    public static class CelestialBodyExtensions
    {
        public static CelestialBody AdaptToDb(this CelestialBody celestialBody)
        {
            celestialBody.BodyParents = new List<CelestialBodyParent>();
            celestialBody.BodyAtmosphereCompositions = new List<CelestialBodyAtmosphereComposition>();
            celestialBody.BodySolidCompositions = new List<CelestialBodySolidComposition>();
            celestialBody.BodyMaterials = new List<CelestialBodyMaterial>();
            foreach (var entity in celestialBody.Parents.OrEmptyIfNull())
            {
                foreach(var entityKey in entity.Keys)
                {
                    celestialBody.BodyParents.Add(new CelestialBodyParent
                    {
                        Body = celestialBody,
                        Key = entityKey,
                        Value = entity[entityKey]
                    });
                }
            }

            foreach (var entity in celestialBody.AtmosphereCompositions.OrEmptyIfNull())
            {
                celestialBody.BodyAtmosphereCompositions.Add(new CelestialBodyAtmosphereComposition
                {
                    Body = celestialBody,
                    Key = entity.Key,
                    Value = entity.Value
                });
            }

            foreach (var entity in celestialBody.SolidCompositions.OrEmptyIfNull())
            {
                celestialBody.BodySolidCompositions.Add(new CelestialBodySolidComposition
                {
                    Body = celestialBody,
                    Key = entity.Key,
                    Value = entity.Value
                });
            }

            foreach (var entity in celestialBody.Materials.OrEmptyIfNull())
            {
                celestialBody.BodyMaterials.Add(new CelestialBodyMaterial
                {
                    Body = celestialBody,
                    Key = entity.Key,
                    Value = entity.Value
                });
            }

            return celestialBody;
        }
    }
}
