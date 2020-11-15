using Microsoft.EntityFrameworkCore.Migrations;

namespace GrozioSalonuISCF.Migrations
{
    public partial class schema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Redagavimas_Salonas_SalonasId",
                table: "Redagavimas");

            migrationBuilder.DropIndex(
                name: "IX_Redagavimas_SalonasId",
                table: "Redagavimas");

            migrationBuilder.DropColumn(
                name: "SalonasId",
                table: "Redagavimas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalonasId",
                table: "Redagavimas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Redagavimas_SalonasId",
                table: "Redagavimas",
                column: "SalonasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Redagavimas_Salonas_SalonasId",
                table: "Redagavimas",
                column: "SalonasId",
                principalTable: "Salonas",
                principalColumn: "SalonasId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
