using Microsoft.EntityFrameworkCore.Migrations;

namespace GrozioSalonuISCF.Migrations
{
    public partial class alteredtablesatsiliepimasandrezervacija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atsiliepimas_Rezervacija_RezervacijaId",
                table: "Atsiliepimas");

            migrationBuilder.DropIndex(
                name: "IX_Atsiliepimas_RezervacijaId",
                table: "Atsiliepimas");

            migrationBuilder.DropColumn(
                name: "RezervacijaId",
                table: "Atsiliepimas");

            migrationBuilder.AddColumn<int>(
                name: "AtsiliepimasId",
                table: "Rezervacija",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_AtsiliepimasId",
                table: "Rezervacija",
                column: "AtsiliepimasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Atsiliepimas_AtsiliepimasId",
                table: "Rezervacija",
                column: "AtsiliepimasId",
                principalTable: "Atsiliepimas",
                principalColumn: "AtsiliepimasId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Atsiliepimas_AtsiliepimasId",
                table: "Rezervacija");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_AtsiliepimasId",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "AtsiliepimasId",
                table: "Rezervacija");

            migrationBuilder.AddColumn<int>(
                name: "RezervacijaId",
                table: "Atsiliepimas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atsiliepimas_RezervacijaId",
                table: "Atsiliepimas",
                column: "RezervacijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atsiliepimas_Rezervacija_RezervacijaId",
                table: "Atsiliepimas",
                column: "RezervacijaId",
                principalTable: "Rezervacija",
                principalColumn: "RezervacijaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
