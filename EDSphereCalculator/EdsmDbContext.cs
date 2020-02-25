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
            modelBuilder.Entity<EdSystem>().HasIndex(_ => _.Id);
            modelBuilder.Entity<EdSystem>().HasIndex(_ => _.EdsmId);
            modelBuilder.Entity<EdSystem>().HasIndex(_ => _.EdsmId64);
            modelBuilder.Entity<EdSystem>().HasIndex(_ => _.CoordinatesId);
            modelBuilder.Entity<EdSystem>().HasIndex(_ => _.Name);


            modelBuilder.Entity<CelestialBody>().HasIndex(_ => _.Id);
            modelBuilder.Entity<CelestialBody>().HasIndex(_ => _.EdsmId);
            modelBuilder.Entity<CelestialBody>().HasIndex(_ => _.Type);
            modelBuilder.Entity<CelestialBody>().HasIndex(_ => _.SubType);
            modelBuilder.Entity<CelestialBody>().HasIndex(_ => _.DistanceToArrival);
            modelBuilder.Entity<CelestialBody>().HasIndex(_ => _.EdsmBodyId);
            modelBuilder.Entity<CelestialBody>().HasIndex(_ => _.EdSystemId);

            modelBuilder.Entity<CelestialBodyAtmosphereComposition>().HasIndex(_ => _.BodyId);

            modelBuilder.Entity<CelestialBodyBelt>().HasIndex(_ => _.BodyId);

            modelBuilder.Entity<CelestialBodyMaterial>().HasIndex(_ => _.BodyId);
            modelBuilder.Entity<CelestialBodyMaterial>().HasIndex(_ => _.Key);

            modelBuilder.Entity<CelestialBodyParent>().HasIndex(_ => _.BodyId);

            modelBuilder.Entity<CelestialBodyRing>().HasIndex(_ => _.BodyId);

            modelBuilder.Entity<CelestialBodySolidComposition>().HasIndex(_ => _.BodyId);
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
