using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrozioSalonuISCF.Migrations
{
    public partial class pridetiRedagavima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Redagavimas",
                columns: table => new
                {
                    RedagavimasId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(nullable: false),
                    priezastis = table.Column<string>(nullable: true),
                    tipas = table.Column<string>(nullable: true),
                    SalonoId = table.Column<int>(nullable: false),
                    SalonasId = table.Column<int>(nullable: true),
                    KlientasId = table.Column<int>(nullable: false),
                    AdminId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redagavimas", x => x.RedagavimasId);
                    table.ForeignKey(
                        name: "FK_Redagavimas_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redagavimas_Klientai_KlientasId",
                        column: x => x.KlientasId,
                        principalTable: "Klientai",
                        principalColumn: "KlientasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redagavimas_Salonas_SalonasId",
                        column: x => x.SalonasId,
                        principalTable: "Salonas",
                        principalColumn: "SalonasId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Redagavimas_AdminId",
                table: "Redagavimas",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Redagavimas_KlientasId",
                table: "Redagavimas",
                column: "KlientasId");

            migrationBuilder.CreateIndex(
                name: "IX_Redagavimas_SalonasId",
                table: "Redagavimas",
                column: "SalonasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Redagavimas");

            migrationBuilder.DropTable(
                name: "Admin");
        }
    }
}
