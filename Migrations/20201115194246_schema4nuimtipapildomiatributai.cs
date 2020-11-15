using Microsoft.EntityFrameworkCore.Migrations;

namespace GrozioSalonuISCF.Migrations
{
    public partial class schema4nuimtipapildomiatributai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Redagavimas_Vartotojas_VartotojasvartId",
                table: "Redagavimas");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Vartotojas_VartotojasvartId",
                table: "Rezervacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Salonas_Vartotojas_VartotojasvartId",
                table: "Salonas");

            migrationBuilder.DropIndex(
                name: "IX_Salonas_VartotojasvartId",
                table: "Salonas");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_VartotojasvartId",
                table: "Rezervacija");

            migrationBuilder.DropIndex(
                name: "IX_Redagavimas_VartotojasvartId",
                table: "Redagavimas");

            migrationBuilder.DropColumn(
                name: "VartotojasvartId",
                table: "Salonas");

            migrationBuilder.DropColumn(
                name: "vartId",
                table: "Salonas");

            migrationBuilder.DropColumn(
                name: "VartotojasvartId",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "vartId",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "VartotojasvartId",
                table: "Redagavimas");

            migrationBuilder.DropColumn(
                name: "vartId",
                table: "Redagavimas");

            migrationBuilder.AddColumn<int>(
                name: "vartotojasId",
                table: "Salonas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vartotojasId",
                table: "Rezervacija",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vartotojasId",
                table: "Redagavimas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salonas_vartotojasId",
                table: "Salonas",
                column: "vartotojasId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_vartotojasId",
                table: "Rezervacija",
                column: "vartotojasId");

            migrationBuilder.CreateIndex(
                name: "IX_Redagavimas_vartotojasId",
                table: "Redagavimas",
                column: "vartotojasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Redagavimas_Vartotojas_vartotojasId",
                table: "Redagavimas",
                column: "vartotojasId",
                principalTable: "Vartotojas",
                principalColumn: "vartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Vartotojas_vartotojasId",
                table: "Rezervacija",
                column: "vartotojasId",
                principalTable: "Vartotojas",
                principalColumn: "vartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salonas_Vartotojas_vartotojasId",
                table: "Salonas",
                column: "vartotojasId",
                principalTable: "Vartotojas",
                principalColumn: "vartId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Redagavimas_Vartotojas_vartotojasId",
                table: "Redagavimas");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Vartotojas_vartotojasId",
                table: "Rezervacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Salonas_Vartotojas_vartotojasId",
                table: "Salonas");

            migrationBuilder.DropIndex(
                name: "IX_Salonas_vartotojasId",
                table: "Salonas");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_vartotojasId",
                table: "Rezervacija");

            migrationBuilder.DropIndex(
                name: "IX_Redagavimas_vartotojasId",
                table: "Redagavimas");

            migrationBuilder.DropColumn(
                name: "vartotojasId",
                table: "Salonas");

            migrationBuilder.DropColumn(
                name: "vartotojasId",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "vartotojasId",
                table: "Redagavimas");

            migrationBuilder.AddColumn<int>(
                name: "VartotojasvartId",
                table: "Salonas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "vartId",
                table: "Salonas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VartotojasvartId",
                table: "Rezervacija",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "vartId",
                table: "Rezervacija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VartotojasvartId",
                table: "Redagavimas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "vartId",
                table: "Redagavimas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salonas_VartotojasvartId",
                table: "Salonas",
                column: "VartotojasvartId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_VartotojasvartId",
                table: "Rezervacija",
                column: "VartotojasvartId");

            migrationBuilder.CreateIndex(
                name: "IX_Redagavimas_VartotojasvartId",
                table: "Redagavimas",
                column: "VartotojasvartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Redagavimas_Vartotojas_VartotojasvartId",
                table: "Redagavimas",
                column: "VartotojasvartId",
                principalTable: "Vartotojas",
                principalColumn: "vartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Vartotojas_VartotojasvartId",
                table: "Rezervacija",
                column: "VartotojasvartId",
                principalTable: "Vartotojas",
                principalColumn: "vartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salonas_Vartotojas_VartotojasvartId",
                table: "Salonas",
                column: "VartotojasvartId",
                principalTable: "Vartotojas",
                principalColumn: "vartId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
