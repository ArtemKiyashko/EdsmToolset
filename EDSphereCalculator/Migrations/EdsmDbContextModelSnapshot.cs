﻿// <auto-generated />
using System;
using EDSphereCalculator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EDSphereCalculator.Migrations
{
    [DbContext(typeof(EdsmDbContext))]
    partial class EdsmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBody", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("AbsoluteMagnitude")
                        .HasColumnType("float");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<double?>("ArgOfPeriapsis")
                        .HasColumnType("float");

                    b.Property<string>("AtmosphereType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("AxialTilt")
                        .HasColumnType("float");

                    b.Property<int>("DistanceToArrival")
                        .HasColumnType("int");

                    b.Property<double?>("EarthMasses")
                        .HasColumnType("float");

                    b.Property<int>("EdSystemId")
                        .HasColumnType("int");

                    b.Property<long?>("EdSystemId64")
                        .HasColumnType("bigint");

                    b.Property<int?>("EdsmBodyId")
                        .HasColumnType("int");

                    b.Property<int>("EdsmId")
                        .HasColumnType("int");

                    b.Property<long?>("EdsmId64")
                        .HasColumnType("bigint");

                    b.Property<double?>("Gravity")
                        .HasColumnType("float");

                    b.Property<bool?>("IsLandable")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsMainStar")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsScoopable")
                        .HasColumnType("bit");

                    b.Property<string>("Luminosity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("OrbitalEccentricity")
                        .HasColumnType("float");

                    b.Property<double?>("OrbitalInclination")
                        .HasColumnType("float");

                    b.Property<double?>("OrbitalPeriod")
                        .HasColumnType("float");

                    b.Property<double?>("Radius")
                        .HasColumnType("float");

                    b.Property<double?>("RotationalPeriod")
                        .HasColumnType("float");

                    b.Property<bool?>("RotationalPeriodTidallyLocked")
                        .HasColumnType("bit");

                    b.Property<double?>("SemiMajorAxis")
                        .HasColumnType("float");

                    b.Property<double?>("SolarMasses")
                        .HasColumnType("float");

                    b.Property<double?>("SolarRadius")
                        .HasColumnType("float");

                    b.Property<string>("SpectralClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("SurfacePressure")
                        .HasColumnType("float");

                    b.Property<int?>("SurfaceTemperature")
                        .HasColumnType("int");

                    b.Property<string>("TerraformingState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("VolcanismType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EdSystemId");

                    b.ToTable("CelestialBodies");
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBodyAtmosphereComposition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BodyId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.ToTable("CelestialBodyAtmosphereCompositions");
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBodyMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BodyId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.ToTable("CelestialBodyMaterials");
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBodyParent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BodyId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.ToTable("CelestialBodyParens");
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBodyRing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BodyId")
                        .HasColumnType("int");

                    b.Property<long>("InnerRadius")
                        .HasColumnType("bigint");

                    b.Property<long>("Mass")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OuterRadius")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.ToTable("CelestialBodyRings");
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBodySolidComposition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BodyId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.ToTable("CelestialBodySolidCompositios");
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.Distance", b =>
                {
                    b.Property<int>("DistanceFromId")
                        .HasColumnType("int");

                    b.Property<int>("DistanceToId")
                        .HasColumnType("int");

                    b.Property<double>("LightYears")
                        .HasColumnType("float");

                    b.HasKey("DistanceFromId", "DistanceToId");

                    b.HasIndex("DistanceToId");

                    b.ToTable("Distances");
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.EdSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoordinatesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EdsmId")
                        .HasColumnType("int");

                    b.Property<long?>("EdsmId64")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoordinatesId");

                    b.ToTable("EdSystems");
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.EdSystemCoordinates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.Property<double>("Z")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("EdSystemCoordinates");
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBody", b =>
                {
                    b.HasOne("EDSphereCalculator.CalculatorModels.EdSystem", "EdSystem")
                        .WithMany("Bodies")
                        .HasForeignKey("EdSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBodyAtmosphereComposition", b =>
                {
                    b.HasOne("EDSphereCalculator.CalculatorModels.CelestialBody", "Body")
                        .WithMany("BodyAtmosphereCompositions")
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBodyMaterial", b =>
                {
                    b.HasOne("EDSphereCalculator.CalculatorModels.CelestialBody", "Body")
                        .WithMany("BodyMaterials")
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBodyParent", b =>
                {
                    b.HasOne("EDSphereCalculator.CalculatorModels.CelestialBody", "Body")
                        .WithMany("BodyParents")
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBodyRing", b =>
                {
                    b.HasOne("EDSphereCalculator.CalculatorModels.CelestialBody", "Body")
                        .WithMany("Rings")
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.CelestialBodySolidComposition", b =>
                {
                    b.HasOne("EDSphereCalculator.CalculatorModels.CelestialBody", "Body")
                        .WithMany("BodySolidCompositions")
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.Distance", b =>
                {
                    b.HasOne("EDSphereCalculator.CalculatorModels.EdSystem", "DistanceFrom")
                        .WithMany("DistancesTo")
                        .HasForeignKey("DistanceFromId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EDSphereCalculator.CalculatorModels.EdSystem", "DistanceTo")
                        .WithMany("DistancesFrom")
                        .HasForeignKey("DistanceToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDSphereCalculator.CalculatorModels.EdSystem", b =>
                {
                    b.HasOne("EDSphereCalculator.CalculatorModels.EdSystemCoordinates", "Coordinates")
                        .WithMany()
                        .HasForeignKey("CoordinatesId");
                });
#pragma warning restore 612, 618
        }
    }
}
