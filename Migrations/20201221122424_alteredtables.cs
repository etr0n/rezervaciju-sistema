using Microsoft.EntityFrameworkCore.Migrations;

namespace GrozioSalonuISCF.Migrations
{
    public partial class alteredtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atsiliepimas_Paslauga_PaslaugaId",
                table: "Atsiliepimas");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Salonas");

            migrationBuilder.DropColumn(
                name: "busenos",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "PaslaugosId",
                table: "Atsiliepimas");

            migrationBuilder.AddColumn<string>(
                name: "busena",
                table: "Rezervacija",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaslaugaId",
                table: "Atsiliepimas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atsiliepimas_Paslauga_PaslaugaId",
                table: "Atsiliepimas",
                column: "PaslaugaId",
                principalTable: "Paslauga",
                principalColumn: "PaslaugaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atsiliepimas_Paslauga_PaslaugaId",
                table: "Atsiliepimas");

            migrationBuilder.DropColumn(
                name: "busena",
                table: "Rezervacija");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Salonas",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "busenos",
                table: "Rezervacija",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "PaslaugaId",
                table: "Atsiliepimas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PaslaugosId",
                table: "Atsiliepimas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Atsiliepimas_Paslauga_PaslaugaId",
                table: "Atsiliepimas",
                column: "PaslaugaId",
                principalTable: "Paslauga",
                principalColumn: "PaslaugaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
