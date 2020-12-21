using Microsoft.EntityFrameworkCore.Migrations;

namespace GrozioSalonuISCF.Migrations
{
    public partial class alteredrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atsiliepimas_Paslauga_PaslaugaId",
                table: "Atsiliepimas");

            migrationBuilder.DropIndex(
                name: "IX_Atsiliepimas_PaslaugaId",
                table: "Atsiliepimas");

            migrationBuilder.DropColumn(
                name: "PaslaugaId",
                table: "Atsiliepimas");

            migrationBuilder.AddColumn<int>(
                name: "RezervacijaId",
                table: "Atsiliepimas",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PaslaugaId",
                table: "Atsiliepimas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atsiliepimas_PaslaugaId",
                table: "Atsiliepimas",
                column: "PaslaugaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atsiliepimas_Paslauga_PaslaugaId",
                table: "Atsiliepimas",
                column: "PaslaugaId",
                principalTable: "Paslauga",
                principalColumn: "PaslaugaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
