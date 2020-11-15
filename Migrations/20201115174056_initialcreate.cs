using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrozioSalonuISCF.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Vartotojas",
                columns: table => new
                {
                    vartId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vartotojas", x => x.vartId);
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
                    MiestasId = table.Column<int>(nullable: false),
                    vartId = table.Column<int>(nullable: false),
                    VartotojasvartId = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Salonas_Vartotojas_VartotojasvartId",
                        column: x => x.VartotojasvartId,
                        principalTable: "Vartotojas",
                        principalColumn: "vartId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Redagavimas",
                columns: table => new
                {
                    RedagavimasId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(nullable: false),
                    priezastis = table.Column<string>(nullable: true),
                    tipas = table.Column<string>(nullable: true),
                    vartId = table.Column<int>(nullable: false),
                    VartotojasvartId = table.Column<int>(nullable: true),
                    SalonasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redagavimas", x => x.RedagavimasId);
                    table.ForeignKey(
                        name: "FK_Redagavimas_Salonas_SalonasId",
                        column: x => x.SalonasId,
                        principalTable: "Salonas",
                        principalColumn: "SalonasId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Redagavimas_Vartotojas_VartotojasvartId",
                        column: x => x.VartotojasvartId,
                        principalTable: "Vartotojas",
                        principalColumn: "vartId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Atsiliepimas",
                columns: table => new
                {
                    AtsiliepimasId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    aprasymas = table.Column<string>(nullable: true),
                    paslaugos_busena = table.Column<bool>(nullable: false),
                    data = table.Column<DateTime>(nullable: false),
                    vardas = table.Column<string>(nullable: true),
                    PaslaugosId = table.Column<int>(nullable: false),
                    PaslaugaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atsiliepimas", x => x.AtsiliepimasId);
                    table.ForeignKey(
                        name: "FK_Atsiliepimas_Paslauga_PaslaugaId",
                        column: x => x.PaslaugaId,
                        principalTable: "Paslauga",
                        principalColumn: "PaslaugaId",
                        onDelete: ReferentialAction.Restrict);
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
                    vartId = table.Column<int>(nullable: false),
                    VartotojasvartId = table.Column<int>(nullable: true),
                    PaslaugaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.nr);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Paslauga_PaslaugaId",
                        column: x => x.PaslaugaId,
                        principalTable: "Paslauga",
                        principalColumn: "PaslaugaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Vartotojas_VartotojasvartId",
                        column: x => x.VartotojasvartId,
                        principalTable: "Vartotojas",
                        principalColumn: "vartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atsiliepimas_PaslaugaId",
                table: "Atsiliepimas",
                column: "PaslaugaId");

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
                name: "IX_Redagavimas_SalonasId",
                table: "Redagavimas",
                column: "SalonasId");

            migrationBuilder.CreateIndex(
                name: "IX_Redagavimas_VartotojasvartId",
                table: "Redagavimas",
                column: "VartotojasvartId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_PaslaugaId",
                table: "Rezervacija",
                column: "PaslaugaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_VartotojasvartId",
                table: "Rezervacija",
                column: "VartotojasvartId");

            migrationBuilder.CreateIndex(
                name: "IX_Salonas_MiestasId",
                table: "Salonas",
                column: "MiestasId");

            migrationBuilder.CreateIndex(
                name: "IX_Salonas_VartotojasvartId",
                table: "Salonas",
                column: "VartotojasvartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atsiliepimas");

            migrationBuilder.DropTable(
                name: "Islaidos");

            migrationBuilder.DropTable(
                name: "Redagavimas");

            migrationBuilder.DropTable(
                name: "Rezervacija");

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

            migrationBuilder.DropTable(
                name: "Vartotojas");
        }
    }
}
