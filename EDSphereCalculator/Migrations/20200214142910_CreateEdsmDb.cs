using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDSphereCalculator.Migrations
{
    public partial class CreateEdsmDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EdSystemCoordinates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdsmId = table.Column<int>(nullable: false),
                    EdsmId64 = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CoordinatesId = table.Column<int>(nullable: true)
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
                name: "CelestialBody",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdsmId = table.Column<int>(nullable: false),
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
                    RotationalPeriodTidallyLocked = table.Column<bool>(nullable: true),
                    AxialTilt = table.Column<double>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    EdSystemId = table.Column<int>(nullable: false),
                    EdSystemId64 = table.Column<long>(nullable: true),
                    IsMainStar = table.Column<bool>(nullable: true),
                    IsScoopable = table.Column<bool>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    SpectralClass = table.Column<string>(nullable: true),
                    Luminosity = table.Column<string>(nullable: true),
                    AbsoluteMagnitude = table.Column<double>(nullable: true),
                    SolarMasses = table.Column<double>(nullable: true),
                    SolarRadius = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBody", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBody_EdSystems_EdSystemId",
                        column: x => x.EdSystemId,
                        principalTable: "EdSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distances",
                columns: table => new
                {
                    DistanceFromId = table.Column<int>(nullable: false),
                    DistanceToId = table.Column<int>(nullable: false),
                    LightYears = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distances", x => new { x.DistanceFromId, x.DistanceToId });
                    table.ForeignKey(
                        name: "FK_Distances_EdSystems_DistanceFromId",
                        column: x => x.DistanceFromId,
                        principalTable: "EdSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Distances_EdSystems_DistanceToId",
                        column: x => x.DistanceToId,
                        principalTable: "EdSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodyAtmosphereComposition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    BodyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodyAtmosphereComposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodyAtmosphereComposition_CelestialBody_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CelestialBody",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodyMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    BodyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodyMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodyMaterials_CelestialBody_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CelestialBody",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodyParent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    BodyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodyParent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodyParent_CelestialBody_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CelestialBody",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodyRing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Mass = table.Column<long>(nullable: false),
                    InnerRadius = table.Column<long>(nullable: false),
                    OuterRadius = table.Column<long>(nullable: false),
                    BodyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodyRing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodyRing_CelestialBody_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CelestialBody",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBodySolidComposition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    BodyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBodySolidComposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBodySolidComposition_CelestialBody_BodyId",
                        column: x => x.BodyId,
                        principalTable: "CelestialBody",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBody_EdSystemId",
                table: "CelestialBody",
                column: "EdSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodyAtmosphereComposition_BodyId",
                table: "CelestialBodyAtmosphereComposition",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodyMaterials_BodyId",
                table: "CelestialBodyMaterials",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodyParent_BodyId",
                table: "CelestialBodyParent",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodyRing_BodyId",
                table: "CelestialBodyRing",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodySolidComposition_BodyId",
                table: "CelestialBodySolidComposition",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Distances_DistanceToId",
                table: "Distances",
                column: "DistanceToId");

            migrationBuilder.CreateIndex(
                name: "IX_EdSystems_CoordinatesId",
                table: "EdSystems",
                column: "CoordinatesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelestialBodyAtmosphereComposition");

            migrationBuilder.DropTable(
                name: "CelestialBodyMaterials");

            migrationBuilder.DropTable(
                name: "CelestialBodyParent");

            migrationBuilder.DropTable(
                name: "CelestialBodyRing");

            migrationBuilder.DropTable(
                name: "CelestialBodySolidComposition");

            migrationBuilder.DropTable(
                name: "Distances");

            migrationBuilder.DropTable(
                name: "CelestialBody");

            migrationBuilder.DropTable(
                name: "EdSystems");

            migrationBuilder.DropTable(
                name: "EdSystemCoordinates");
        }
    }
}
