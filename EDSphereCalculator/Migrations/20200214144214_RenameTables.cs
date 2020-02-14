using Microsoft.EntityFrameworkCore.Migrations;

namespace EDSphereCalculator.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBody_EdSystems_EdSystemId",
                table: "CelestialBody");

            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodyAtmosphereComposition_CelestialBody_BodyId",
                table: "CelestialBodyAtmosphereComposition");

            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodyMaterials_CelestialBody_BodyId",
                table: "CelestialBodyMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodyParent_CelestialBody_BodyId",
                table: "CelestialBodyParent");

            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodyRing_CelestialBody_BodyId",
                table: "CelestialBodyRing");

            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodySolidComposition_CelestialBody_BodyId",
                table: "CelestialBodySolidComposition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CelestialBodySolidComposition",
                table: "CelestialBodySolidComposition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CelestialBodyRing",
                table: "CelestialBodyRing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CelestialBodyParent",
                table: "CelestialBodyParent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CelestialBodyAtmosphereComposition",
                table: "CelestialBodyAtmosphereComposition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CelestialBody",
                table: "CelestialBody");

            migrationBuilder.RenameTable(
                name: "CelestialBodySolidComposition",
                newName: "CelestialBodySolidCompositios");

            migrationBuilder.RenameTable(
                name: "CelestialBodyRing",
                newName: "CelestialBodyRings");

            migrationBuilder.RenameTable(
                name: "CelestialBodyParent",
                newName: "CelestialBodyParens");

            migrationBuilder.RenameTable(
                name: "CelestialBodyAtmosphereComposition",
                newName: "CelestialBodyAtmosphereCompositions");

            migrationBuilder.RenameTable(
                name: "CelestialBody",
                newName: "CelestialBodies");

            migrationBuilder.RenameIndex(
                name: "IX_CelestialBodySolidComposition_BodyId",
                table: "CelestialBodySolidCompositios",
                newName: "IX_CelestialBodySolidCompositios_BodyId");

            migrationBuilder.RenameIndex(
                name: "IX_CelestialBodyRing_BodyId",
                table: "CelestialBodyRings",
                newName: "IX_CelestialBodyRings_BodyId");

            migrationBuilder.RenameIndex(
                name: "IX_CelestialBodyParent_BodyId",
                table: "CelestialBodyParens",
                newName: "IX_CelestialBodyParens_BodyId");

            migrationBuilder.RenameIndex(
                name: "IX_CelestialBodyAtmosphereComposition_BodyId",
                table: "CelestialBodyAtmosphereCompositions",
                newName: "IX_CelestialBodyAtmosphereCompositions_BodyId");

            migrationBuilder.RenameIndex(
                name: "IX_CelestialBody_EdSystemId",
                table: "CelestialBodies",
                newName: "IX_CelestialBodies_EdSystemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CelestialBodySolidCompositios",
                table: "CelestialBodySolidCompositios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CelestialBodyRings",
                table: "CelestialBodyRings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CelestialBodyParens",
                table: "CelestialBodyParens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CelestialBodyAtmosphereCompositions",
                table: "CelestialBodyAtmosphereCompositions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CelestialBodies",
                table: "CelestialBodies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodies_EdSystems_EdSystemId",
                table: "CelestialBodies",
                column: "EdSystemId",
                principalTable: "EdSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyAtmosphereCompositions_CelestialBodies_BodyId",
                table: "CelestialBodyAtmosphereCompositions",
                column: "BodyId",
                principalTable: "CelestialBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyMaterials_CelestialBodies_BodyId",
                table: "CelestialBodyMaterials",
                column: "BodyId",
                principalTable: "CelestialBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyParens_CelestialBodies_BodyId",
                table: "CelestialBodyParens",
                column: "BodyId",
                principalTable: "CelestialBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyRings_CelestialBodies_BodyId",
                table: "CelestialBodyRings",
                column: "BodyId",
                principalTable: "CelestialBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodySolidCompositios_CelestialBodies_BodyId",
                table: "CelestialBodySolidCompositios",
                column: "BodyId",
                principalTable: "CelestialBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodies_EdSystems_EdSystemId",
                table: "CelestialBodies");

            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodyAtmosphereCompositions_CelestialBodies_BodyId",
                table: "CelestialBodyAtmosphereCompositions");

            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodyMaterials_CelestialBodies_BodyId",
                table: "CelestialBodyMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodyParens_CelestialBodies_BodyId",
                table: "CelestialBodyParens");

            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodyRings_CelestialBodies_BodyId",
                table: "CelestialBodyRings");

            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodySolidCompositios_CelestialBodies_BodyId",
                table: "CelestialBodySolidCompositios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CelestialBodySolidCompositios",
                table: "CelestialBodySolidCompositios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CelestialBodyRings",
                table: "CelestialBodyRings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CelestialBodyParens",
                table: "CelestialBodyParens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CelestialBodyAtmosphereCompositions",
                table: "CelestialBodyAtmosphereCompositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CelestialBodies",
                table: "CelestialBodies");

            migrationBuilder.RenameTable(
                name: "CelestialBodySolidCompositios",
                newName: "CelestialBodySolidComposition");

            migrationBuilder.RenameTable(
                name: "CelestialBodyRings",
                newName: "CelestialBodyRing");

            migrationBuilder.RenameTable(
                name: "CelestialBodyParens",
                newName: "CelestialBodyParent");

            migrationBuilder.RenameTable(
                name: "CelestialBodyAtmosphereCompositions",
                newName: "CelestialBodyAtmosphereComposition");

            migrationBuilder.RenameTable(
                name: "CelestialBodies",
                newName: "CelestialBody");

            migrationBuilder.RenameIndex(
                name: "IX_CelestialBodySolidCompositios_BodyId",
                table: "CelestialBodySolidComposition",
                newName: "IX_CelestialBodySolidComposition_BodyId");

            migrationBuilder.RenameIndex(
                name: "IX_CelestialBodyRings_BodyId",
                table: "CelestialBodyRing",
                newName: "IX_CelestialBodyRing_BodyId");

            migrationBuilder.RenameIndex(
                name: "IX_CelestialBodyParens_BodyId",
                table: "CelestialBodyParent",
                newName: "IX_CelestialBodyParent_BodyId");

            migrationBuilder.RenameIndex(
                name: "IX_CelestialBodyAtmosphereCompositions_BodyId",
                table: "CelestialBodyAtmosphereComposition",
                newName: "IX_CelestialBodyAtmosphereComposition_BodyId");

            migrationBuilder.RenameIndex(
                name: "IX_CelestialBodies_EdSystemId",
                table: "CelestialBody",
                newName: "IX_CelestialBody_EdSystemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CelestialBodySolidComposition",
                table: "CelestialBodySolidComposition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CelestialBodyRing",
                table: "CelestialBodyRing",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CelestialBodyParent",
                table: "CelestialBodyParent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CelestialBodyAtmosphereComposition",
                table: "CelestialBodyAtmosphereComposition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CelestialBody",
                table: "CelestialBody",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBody_EdSystems_EdSystemId",
                table: "CelestialBody",
                column: "EdSystemId",
                principalTable: "EdSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyAtmosphereComposition_CelestialBody_BodyId",
                table: "CelestialBodyAtmosphereComposition",
                column: "BodyId",
                principalTable: "CelestialBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyMaterials_CelestialBody_BodyId",
                table: "CelestialBodyMaterials",
                column: "BodyId",
                principalTable: "CelestialBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyParent_CelestialBody_BodyId",
                table: "CelestialBodyParent",
                column: "BodyId",
                principalTable: "CelestialBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyRing_CelestialBody_BodyId",
                table: "CelestialBodyRing",
                column: "BodyId",
                principalTable: "CelestialBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodySolidComposition_CelestialBody_BodyId",
                table: "CelestialBodySolidComposition",
                column: "BodyId",
                principalTable: "CelestialBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
