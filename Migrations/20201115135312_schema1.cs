using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrozioSalonuISCF.Migrations
{
    public partial class schema1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klientai",
                columns: table => new
                {
                    KlientasId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Vardas = table.Column<string>(nullable: true),
                    Pavarde = table.Column<string>(nullable: true),
                    GimimoData = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klientai", x => x.KlientasId);
                });

            migrationBuilder.CreateTable(
                name: "Miestas",
                columns: table => new
                {
                    MiestasId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pavadinimas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miestas", x => x.MiestasId);
                });

            migrationBuilder.CreateTable(
                name: "PaslaugosTipas",
                columns: table => new
                {
                    PaslaugosTipasId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pavadinimas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaslaugosTipas", x => x.PaslaugosTipasId);
                });

            migrationBuilder.CreateTable(
                name: "Salonas",
                columns: table => new
                {
                    SalonasId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pavadinimas = table.Column<string>(nullable: true),
                    imones_kodas = table.Column<string>(nullable: true),
                    adresas = table.Column<string>(nullable: true),
                    tel_nr = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    ikurimo_data = table.Column<DateTime>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    MiestasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salonas", x => x.SalonasId);
                    table.ForeignKey(
                        name: "FK_Salonas_Miestas_MiestasId",
                        column: x => x.MiestasId,
                        principalTable: "Miestas",
                        principalColumn: "MiestasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Darbuotojas",
                columns: table => new
                {
                    DarbuotojasId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Vardas = table.Column<string>(nullable: true),
                    Pavarde = table.Column<string>(nullable: true),
                    tel_nr = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    SalonasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Darbuotojas", x => x.DarbuotojasId);
                    table.ForeignKey(
                        name: "FK_Darbuotojas_Salonas_SalonasId",
                        column: x => x.SalonasId,
                        principalTable: "Salonas",
                        principalColumn: "SalonasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Islaidos",
                columns: table => new
                {
                    IslaidosId = table.Column<string>(nullable: false),
                    suma = table.Column<float>(nullable: false),
                    paskirtis = table.Column<string>(nullable: true),
                    data = table.Column<DateTime>(nullable: false),
                    SalonasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islaidos", x => x.IslaidosId);
                    table.ForeignKey(
                        name: "FK_Islaidos_Salonas_SalonasId",
                        column: x => x.SalonasId,
                        principalTable: "Salonas",
                        principalColumn: "SalonasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paslauga",
                columns: table => new
                {
                    PaslaugaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pavadinimas = table.Column<string>(nullable: true),
                    aprasymas = table.Column<string>(nullable: true),
                    kaina = table.Column<float>(nullable: false),
                    trukme = table.Column<float>(nullable: false),
                    priemones = table.Column<string>(nullable: true),
                    rekomendacijos = table.Column<string>(nullable: true),
                    DarbuotojasId = table.Column<int>(nullable: false),
                    SalonasId = table.Column<int>(nullable: false),
                    PaslaugosTipasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paslauga", x => x.PaslaugaId);
                    table.ForeignKey(
                        name: "FK_Paslauga_Darbuotojas_DarbuotojasId",
                        column: x => x.DarbuotojasId,
                        principalTable: "Darbuotojas",
                        principalColumn: "DarbuotojasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paslauga_PaslaugosTipas_PaslaugosTipasId",
                        column: x => x.PaslaugosTipasId,
                        principalTable: "PaslaugosTipas",
                        principalColumn: "PaslaugosTipasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paslauga_Salonas_SalonasId",
                        column: x => x.SalonasId,
                        principalTable: "Salonas",
                        principalColumn: "SalonasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    nr = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    proc_prad = table.Column<DateTime>(nullable: false),
                    data = table.Column<DateTime>(nullable: false),
                    busenos = table.Column<bool>(nullable: false),
                    KlientasId = table.Column<int>(nullable: false),
                    PaslaugaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.nr);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Klientai_KlientasId",
                        column: x => x.KlientasId,
                        principalTable: "Klientai",
                        principalColumn: "KlientasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Paslauga_PaslaugaId",
                        column: x => x.PaslaugaId,
                        principalTable: "Paslauga",
                        principalColumn: "PaslaugaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Darbuotojas_SalonasId",
                table: "Darbuotojas",
                column: "SalonasId");

            migrationBuilder.CreateIndex(
                name: "IX_Islaidos_SalonasId",
                table: "Islaidos",
                column: "SalonasId");

            migrationBuilder.CreateIndex(
                name: "IX_Paslauga_DarbuotojasId",
                table: "Paslauga",
                column: "DarbuotojasId");

            migrationBuilder.CreateIndex(
                name: "IX_Paslauga_PaslaugosTipasId",
                table: "Paslauga",
                column: "PaslaugosTipasId");

            migrationBuilder.CreateIndex(
                name: "IX_Paslauga_SalonasId",
                table: "Paslauga",
                column: "SalonasId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KlientasId",
                table: "Rezervacija",
                column: "KlientasId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_PaslaugaId",
                table: "Rezervacija",
                column: "PaslaugaId");

            migrationBuilder.CreateIndex(
                name: "IX_Salonas_MiestasId",
                table: "Salonas",
                column: "MiestasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Islaidos");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Klientai");

            migrationBuilder.DropTable(
                name: "Paslauga");

            migrationBuilder.DropTable(
                name: "Darbuotojas");

            migrationBuilder.DropTable(
                name: "PaslaugosTipas");

            migrationBuilder.DropTable(
                name: "Salonas");

            migrationBuilder.DropTable(
                name: "Miestas");
        }
    }
}
