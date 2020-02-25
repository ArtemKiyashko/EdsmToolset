using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EdsmDbImporter.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EdSystemCoordinates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Z = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdSystemCoordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EdSystems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EdsmId = table.Column<long>(nullable: false),
                    EdsmId64 = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CoordinatesId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EdSystems_EdSystemCoordinates_CoordinatesId",
                        column: x => x.CoordinatesId,
                        principalTable: "EdSystemCoordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EdsmId = table.Column<long>(nullable: false),
                    EdsmId64 = table.Column<long>(nullable: true),
                    EdsmBodyId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    SubType = table.Column<string>(nullable: false),
                    DistanceToArrival = table.Column<int>(nullable: false),
                    IsLandable = table.Column<bool>(nullable: true),
                    Gravity = table.Column<double>(nullable: true),
                    EarthMasses = table.Column<double>(nullable: true),
                    Radius = table.Column<double>(nullable: true),
                    SurfaceTemperature = table.Column<int>(nullable: true),
                    SurfacePressure = table.Column<double>(nullable: true),
                    VolcanismType = table.Column<string>(nullable: true),
                    AtmosphereType = table.Column<string>(nullable: true),
                    TerraformingState = table.Column<string>(nullable: true),
                    OrbitalPeriod = table.Column<double>(nullable: true),
                    SemiMajorAxis = table.Column<double>(nullable: true),
                    OrbitalEccentricity = table.Column<double>(nullable: true),
                    OrbitalInclination = table.Column<double>(nullable: true),
                    ArgOfPeriapsis = table.Column<double>(nullable: true),
                    RotationalPeriod = table.Column<double>(nullable: true),
                    RotationalPeriodTidallyLocked = table.Column<bool>(nullable: false),
                    AxialTilt = table.Column<double>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    EdSystemId = table.Column<long>(nullable: false),
                    EdSystemId64 = table.Column<long>(nullable: true),
                    IsMainStar = table.Column<bool>(nullable: true),
                    IsScoopable = table.Column<bool>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    SpectralClass = table.Column<string>(nullable: true),
                    Luminosity = table.Column<string>(nullable: true),
                    AbsoluteMagnitude = table.Column<double>(nullable: true),
                    SolarMasses = table.Column<double>(nullable: true),
                    SolarRadius = table.Column<double>(nullable: true),
                    EdSystemName = table.Column<string>(nullable: true),
                    ReserveLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodies_EdSystems_EdsmId",
                        column: x => x.EdSystemId,
                        principalTable: "EdSystems",
                        principalColumn: "EdsmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodyAtmosphereCompositions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    BodyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodyAtmosphereCompositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodyAtmosphereCompositions_CelestialBodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CelestialBodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodyBelts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Mass = table.Column<long>(nullable: false),
                    InnerRadius = table.Column<long>(nullable: false),
                    OuterRadius = table.Column<long>(nullable: false),
                    BodyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodyBelts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodyBelts_CelestialBodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CelestialBodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodyMaterials",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    BodyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodyMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodyMaterials_CelestialBodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CelestialBodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodyParents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    BodyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodyParents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodyParents_CelestialBodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CelestialBodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodyRings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Mass = table.Column<long>(nullable: false),
                    InnerRadius = table.Column<long>(nullable: false),
                    OuterRadius = table.Column<long>(nullable: false),
                    BodyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodyRings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodyRings_CelestialBodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CelestialBodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodySolidCompositios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    BodyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodySolidCompositios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodySolidCompositios_CelestialBodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CelestialBodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodies_EdSystemId",
                table: "CelestialBodies",
                column: "EdSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodyAtmosphereCompositions_BodyId",
                table: "CelestialBodyAtmosphereCompositions",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodyBelts_BodyId",
                table: "CelestialBodyBelts",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodyMaterials_BodyId",
                table: "CelestialBodyMaterials",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodyParents_BodyId",
                table: "CelestialBodyParents",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodyRings_BodyId",
                table: "CelestialBodyRings",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodySolidCompositios_BodyId",
                table: "CelestialBodySolidCompositios",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_EdSystems_CoordinatesId",
                table: "EdSystems",
                column: "CoordinatesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelestialBodyAtmosphereCompositions");

            migrationBuilder.DropTable(
                name: "CelestialBodyBelts");

            migrationBuilder.DropTable(
                name: "CelestialBodyMaterials");

            migrationBuilder.DropTable(
                name: "CelestialBodyParents");

            migrationBuilder.DropTable(
                name: "CelestialBodyRings");

            migrationBuilder.DropTable(
                name: "CelestialBodySolidCompositios");

            migrationBuilder.DropTable(
                name: "CelestialBodies");

            migrationBuilder.DropTable(
                name: "EdSystems");

            migrationBuilder.DropTable(
                name: "EdSystemCoordinates");
        }
    }
}
