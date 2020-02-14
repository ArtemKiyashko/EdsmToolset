using Microsoft.EntityFrameworkCore.Migrations;

namespace EDSphereCalculator.Migrations
{
    public partial class AddConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<int>(
                name: "BodyId",
                table: "CelestialBodySolidComposition",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BodyId",
                table: "CelestialBodyRing",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BodyId",
                table: "CelestialBodyParent",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BodyId",
                table: "CelestialBodyMaterials",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BodyId",
                table: "CelestialBodyAtmosphereComposition",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<int>(
                name: "BodyId",
                table: "CelestialBodySolidComposition",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BodyId",
                table: "CelestialBodyRing",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BodyId",
                table: "CelestialBodyParent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BodyId",
                table: "CelestialBodyMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BodyId",
                table: "CelestialBodyAtmosphereComposition",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyAtmosphereComposition_CelestialBody_BodyId",
                table: "CelestialBodyAtmosphereComposition",
                column: "BodyId",
                principalTable: "CelestialBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyMaterials_CelestialBody_BodyId",
                table: "CelestialBodyMaterials",
                column: "BodyId",
                principalTable: "CelestialBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyParent_CelestialBody_BodyId",
                table: "CelestialBodyParent",
                column: "BodyId",
                principalTable: "CelestialBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodyRing_CelestialBody_BodyId",
                table: "CelestialBodyRing",
                column: "BodyId",
                principalTable: "CelestialBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodySolidComposition_CelestialBody_BodyId",
                table: "CelestialBodySolidComposition",
                column: "BodyId",
                principalTable: "CelestialBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
