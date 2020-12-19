using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrozioSalonuISCF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redagavimas", x => x.RedagavimasId);
                    table.ForeignKey(
                        name: "FK_Redagavimas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UserId = table.Column<string>(nullable: true)
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
                        name: "FK_Salonas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Darbuotojas",
                columns: table => new
                {
                    DarbuotojasId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vardas = table.Column<string>(nullable: true),
                    pavarde = table.Column<string>(nullable: true),
                    tel_nr = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    adresas = table.Column<string>(nullable: true),
                    gimimo_data = table.Column<DateTime>(nullable: false),
                    stazas = table.Column<int>(nullable: false),
                    pareigos = table.Column<string>(nullable: true),
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
                    IslaidosId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    RezervacijaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    proc_prad = table.Column<DateTime>(nullable: false),
                    data = table.Column<DateTime>(nullable: false),
                    busenos = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    PaslaugaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaId);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Paslauga_PaslaugaId",
                        column: x => x.PaslaugaId,
                        principalTable: "Paslauga",
                        principalColumn: "PaslaugaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "IX_Redagavimas_UserId",
                table: "Redagavimas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_PaslaugaId",
                table: "Rezervacija",
                column: "PaslaugaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_UserId",
                table: "Rezervacija",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Salonas_MiestasId",
                table: "Salonas",
                column: "MiestasId");

            migrationBuilder.CreateIndex(
                name: "IX_Salonas_UserId",
                table: "Salonas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Atsiliepimas");

            migrationBuilder.DropTable(
                name: "Islaidos");

            migrationBuilder.DropTable(
                name: "Redagavimas");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "AspNetUsers");
        }
    }
}
