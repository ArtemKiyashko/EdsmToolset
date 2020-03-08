using Microsoft.EntityFrameworkCore.Migrations;

namespace EdsmDbImporter.Migrations
{
    public partial class addGravityIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CelestialBodies_Gravity",
                table: "CelestialBodies",
                column: "Gravity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CelestialBodies_Gravity",
                table: "CelestialBodies");
        }
    }
}
