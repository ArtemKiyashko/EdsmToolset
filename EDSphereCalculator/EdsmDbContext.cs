using EDSphereCalculator.CalculatorModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EDSphereCalculator
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
            modelBuilder.Entity<Distance>().HasKey(c => new { c.DistanceFromId, c.DistanceToId });
            modelBuilder.Entity<EdSystem>()
                .HasMany(s => s.DistancesFrom)
                .WithOne(d => d.DistanceTo)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<EdSystem>()
                .HasMany(s => s.DistancesTo)
                .WithOne(d => d.DistanceFrom)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<EdSystem> EdSystems { get; set; }
        public DbSet<Distance> Distances { get; set; }
        public DbSet<CelestialBody> CelestialBodies { get; set; }
        public DbSet<CelestialBodyAtmosphereComposition> CelestialBodyAtmosphereCompositions { get; set; }
        public DbSet<CelestialBodyMaterial> CelestialBodyMaterials { get; set; }
        public DbSet<CelestialBodyParent> CelestialBodyParens { get; set; }
        public DbSet<CelestialBodyRing> CelestialBodyRings { get; set; }
        public DbSet<CelestialBodySolidComposition> CelestialBodySolidCompositios { get; set; }
    }
}
