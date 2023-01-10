using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aplikacija.Migrations
{
    public partial class neki : Migration
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
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    KategorijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaID);
                });

            migrationBuilder.CreateTable(
                name: "Proizvajalec",
                columns: table => new
                {
                    ProizvajalecID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    Opis = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvajalec", x => x.ProizvajalecID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "TipPrevzema",
                columns: table => new
                {
                    TipPrevzemaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipPrevzema", x => x.TipPrevzemaID);
                });

            migrationBuilder.CreateTable(
                name: "VrstaPlacila",
                columns: table => new
                {
                    VrstaPlacilaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaPlacila", x => x.VrstaPlacilaID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Oseba",
                columns: table => new
                {
                    OsebaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Priimek = table.Column<string>(maxLength: 50, nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    znesekKosarice = table.Column<decimal>(type: "money", nullable: false),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oseba", x => x.OsebaID);
                    table.ForeignKey(
                        name: "FK_Oseba_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    ArtikelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategorijaID = table.Column<int>(nullable: false),
                    ProizvajalecID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Zaloga = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.ArtikelID);
                    table.ForeignKey(
                        name: "FK_Artikel_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artikel_Proizvajalec_ProizvajalecID",
                        column: x => x.ProizvajalecID,
                        principalTable: "Proizvajalec",
                        principalColumn: "ProizvajalecID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Naslov",
                columns: table => new
                {
                    NaslovID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsebaID = table.Column<int>(nullable: false),
                    HisnaSt = table.Column<int>(nullable: false),
                    Ulica = table.Column<string>(nullable: false),
                    Posta = table.Column<int>(nullable: false),
                    Mesto = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naslov", x => x.NaslovID);
                    table.ForeignKey(
                        name: "FK_Naslov_Oseba_OsebaID",
                        column: x => x.OsebaID,
                        principalTable: "Oseba",
                        principalColumn: "OsebaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtikelVKosarici",
                columns: table => new
                {
                    ArtikelID = table.Column<int>(nullable: false),
                    OsebaID = table.Column<int>(nullable: false),
                    kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtikelVKosarici", x => new { x.ArtikelID, x.OsebaID });
                    table.ForeignKey(
                        name: "FK_ArtikelVKosarici_Artikel_ArtikelID",
                        column: x => x.ArtikelID,
                        principalTable: "Artikel",
                        principalColumn: "ArtikelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtikelVKosarici_Oseba_OsebaID",
                        column: x => x.OsebaID,
                        principalTable: "Oseba",
                        principalColumn: "OsebaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocena",
                columns: table => new
                {
                    OcenaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsebaID = table.Column<int>(nullable: false),
                    ArtikelID = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(maxLength: 50, nullable: false),
                    Vrednost = table.Column<int>(nullable: false),
                    potrjenNakup = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocena", x => x.OcenaID);
                    table.ForeignKey(
                        name: "FK_Ocena_Artikel_ArtikelID",
                        column: x => x.ArtikelID,
                        principalTable: "Artikel",
                        principalColumn: "ArtikelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocena_Oseba_OsebaID",
                        column: x => x.OsebaID,
                        principalTable: "Oseba",
                        principalColumn: "OsebaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narocilo",
                columns: table => new
                {
                    NarociloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsebaID = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    NaslovID = table.Column<int>(nullable: false),
                    TipPrevzemaID = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    skupniZnesek = table.Column<decimal>(type: "money", nullable: false),
                    OsebaID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narocilo", x => x.NarociloID);
                    table.ForeignKey(
                        name: "FK_Narocilo_Naslov_NaslovID",
                        column: x => x.NaslovID,
                        principalTable: "Naslov",
                        principalColumn: "NaslovID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narocilo_Oseba_OsebaID",
                        column: x => x.OsebaID,
                        principalTable: "Oseba",
                        principalColumn: "OsebaID");
                    table.ForeignKey(
                        name: "FK_Narocilo_Oseba_OsebaID1",
                        column: x => x.OsebaID1,
                        principalTable: "Oseba",
                        principalColumn: "OsebaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narocilo_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narocilo_TipPrevzema_TipPrevzemaID",
                        column: x => x.TipPrevzemaID,
                        principalTable: "TipPrevzema",
                        principalColumn: "TipPrevzemaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Postavka",
                columns: table => new
                {
                    ArtikelID = table.Column<int>(nullable: false),
                    NarociloID = table.Column<int>(nullable: false),
                    kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postavka", x => new { x.ArtikelID, x.NarociloID });
                    table.ForeignKey(
                        name: "FK_Postavka_Artikel_ArtikelID",
                        column: x => x.ArtikelID,
                        principalTable: "Artikel",
                        principalColumn: "ArtikelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postavka_Narocilo_NarociloID",
                        column: x => x.NarociloID,
                        principalTable: "Narocilo",
                        principalColumn: "NarociloID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    RacunID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarociloID = table.Column<int>(nullable: false),
                    VrstaPlacilaID = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.RacunID);
                    table.ForeignKey(
                        name: "FK_Racun_Narocilo_NarociloID",
                        column: x => x.NarociloID,
                        principalTable: "Narocilo",
                        principalColumn: "NarociloID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racun_VrstaPlacila_VrstaPlacilaID",
                        column: x => x.VrstaPlacilaID,
                        principalTable: "VrstaPlacila",
                        principalColumn: "VrstaPlacilaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikel_KategorijaID",
                table: "Artikel",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Artikel_ProizvajalecID",
                table: "Artikel",
                column: "ProizvajalecID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtikelVKosarici_OsebaID",
                table: "ArtikelVKosarici",
                column: "OsebaID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Narocilo_NaslovID",
                table: "Narocilo",
                column: "NaslovID");

            migrationBuilder.CreateIndex(
                name: "IX_Narocilo_OsebaID",
                table: "Narocilo",
                column: "OsebaID");

            migrationBuilder.CreateIndex(
                name: "IX_Narocilo_OsebaID1",
                table: "Narocilo",
                column: "OsebaID1");

            migrationBuilder.CreateIndex(
                name: "IX_Narocilo_StatusID",
                table: "Narocilo",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Narocilo_TipPrevzemaID",
                table: "Narocilo",
                column: "TipPrevzemaID");

            migrationBuilder.CreateIndex(
                name: "IX_Naslov_OsebaID",
                table: "Naslov",
                column: "OsebaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocena_ArtikelID",
                table: "Ocena",
                column: "ArtikelID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocena_OsebaID",
                table: "Ocena",
                column: "OsebaID");

            migrationBuilder.CreateIndex(
                name: "IX_Oseba_OwnerId",
                table: "Oseba",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Postavka_NarociloID",
                table: "Postavka",
                column: "NarociloID");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_NarociloID",
                table: "Racun",
                column: "NarociloID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Racun_VrstaPlacilaID",
                table: "Racun",
                column: "VrstaPlacilaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtikelVKosarici");

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
                name: "Ocena");

            migrationBuilder.DropTable(
                name: "Postavka");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Narocilo");

            migrationBuilder.DropTable(
                name: "VrstaPlacila");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Proizvajalec");

            migrationBuilder.DropTable(
                name: "Naslov");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TipPrevzema");

            migrationBuilder.DropTable(
                name: "Oseba");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
