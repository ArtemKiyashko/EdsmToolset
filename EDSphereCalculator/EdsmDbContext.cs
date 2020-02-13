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

        public DbSet<Star> Stars { get; set; }
        public DbSet<Distance> Distances { get; set; }
    }
}
