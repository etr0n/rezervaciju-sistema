using Microsoft.EntityFrameworkCore.Migrations;

namespace GrozioSalonuISCF.Migrations
{
    public partial class schema3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Vartotojas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Vartotojas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Vartotojas");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Vartotojas");
        }
    }
}
