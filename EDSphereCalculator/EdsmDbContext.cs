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
            modelBuilder.Entity<Star>()
                .HasMany(s => s.DistancesFrom)
                .WithOne(d => d.DistanceTo)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Star>()
                .HasMany(s => s.DistancesTo)
                .WithOne(d => d.DistanceFrom)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Star> Stars { get; set; }
        public DbSet<Distance> Distances { get; set; }
    }
}
