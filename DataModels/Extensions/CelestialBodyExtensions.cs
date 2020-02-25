using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModels.Extensions
{
    public static class CelestialBodyExtensions
    {
        public static CelestialBody AdaptToDb(this CelestialBody celestialBody)
        {
            celestialBody.BodyParents = new List<CelestialBodyParent>();
            celestialBody.BodyAtmosphereCompositions = new List<CelestialBodyAtmosphereComposition>();
            celestialBody.BodySolidCompositions = new List<CelestialBodySolidComposition>();
            celestialBody.BodyMaterials = new List<CelestialBodyMaterial>();
           
            var currentParents = celestialBody.Parents.OrEmptyIfNull().SelectMany(_ => _);
            var newParents = currentParents.GroupBy(d => d.Key)
                .Select(
                    g => new
                    {
                        g.Key,
                        Value = g.Sum(s => s.Value),
                    });

            foreach (var entityKey in newParents)
            {
                celestialBody.BodyParents.Add(new CelestialBodyParent
                {
                    Body = celestialBody,
                    Key = entityKey.Key,
                    Value = entityKey.Value
                });
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
