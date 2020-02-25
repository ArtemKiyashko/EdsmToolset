using EdsmDbImporter.CalculatorModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EdsmDbImporter
{
    public class EdsmDbContext : DbContext
    {
        public EdsmDbContext()
        {
        }

        public EdsmDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<EdSystem> EdSystems { get; set; }
        public DbSet<CelestialBody> CelestialBodies { get; set; }
        public DbSet<CelestialBodyAtmosphereComposition> CelestialBodyAtmosphereCompositions { get; set; }
        public DbSet<CelestialBodyMaterial> CelestialBodyMaterials { get; set; }
        public DbSet<CelestialBodyParent> CelestialBodyParents { get; set; }
        public DbSet<CelestialBodyRing> CelestialBodyRings { get; set; }
        public DbSet<CelestialBodySolidComposition> CelestialBodySolidCompositios { get; set; }
        public DbSet<CelestialBodyBelt> CelestialBodyBelts { get; set; }
    }
}
