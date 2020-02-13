using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDSphereCalculator.Migrations
{
    public partial class CreateEdsmDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StarCoordinates",
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
                    table.PrimaryKey("PK_StarCoordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stars",
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
                    table.PrimaryKey("PK_Stars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stars_StarCoordinates_CoordinatesId",
                        column: x => x.CoordinatesId,
                        principalTable: "StarCoordinates",
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
                    Name = table.Column<string>(nullable: false),
                    StarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBody", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialBody_Stars_StarId",
                        column: x => x.StarId,
                        principalTable: "Stars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Distances_Stars_DistanceFromId",
                        column: x => x.DistanceFromId,
                        principalTable: "Stars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Distances_Stars_DistanceToId",
                        column: x => x.DistanceToId,
                        principalTable: "Stars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBody_StarId",
                table: "CelestialBody",
                column: "StarId");

            migrationBuilder.CreateIndex(
                name: "IX_Distances_DistanceToId",
                table: "Distances",
                column: "DistanceToId");

            migrationBuilder.CreateIndex(
                name: "IX_Stars_CoordinatesId",
                table: "Stars",
                column: "CoordinatesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelestialBody");

            migrationBuilder.DropTable(
                name: "Distances");

            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "StarCoordinates");
        }
    }
}
