using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestemmingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Plaats = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Land = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestemmingen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leeftijdscategorien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MinLeeftijd = table.Column<int>(type: "int", nullable: false),
                    MaxLeeftijd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leeftijdscategorien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Themas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KleurHex = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Wachtwoord = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    Lid = table.Column<bool>(type: "bit", nullable: false),
                    MedischeGegevens = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Aanmaakdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeeftijdscategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gebruikers_Leeftijdscategorien_LeeftijdscategorieId",
                        column: x => x.LeeftijdscategorieId,
                        principalTable: "Leeftijdscategorien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groepsreizen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Einddatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prijs = table.Column<decimal>(type: "money", nullable: false),
                    Aanmaakdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeeftijdscategorieId = table.Column<int>(type: "int", nullable: false),
                    BestemmingId = table.Column<int>(type: "int", nullable: true),
                    ThemaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groepsreizen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groepsreizen_Bestemmingen_BestemmingId",
                        column: x => x.BestemmingId,
                        principalTable: "Bestemmingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Groepsreizen_Leeftijdscategorien_LeeftijdscategorieId",
                        column: x => x.LeeftijdscategorieId,
                        principalTable: "Leeftijdscategorien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groepsreizen_Themas_ThemaId",
                        column: x => x.ThemaId,
                        principalTable: "Themas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Inschrijvingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroepsreisId = table.Column<int>(type: "int", nullable: false),
                    GebruikerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijvingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_Groepsreizen_GroepsreisId",
                        column: x => x.GroepsreisId,
                        principalTable: "Groepsreizen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_LeeftijdscategorieId",
                table: "Gebruikers",
                column: "LeeftijdscategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Groepsreizen_BestemmingId",
                table: "Groepsreizen",
                column: "BestemmingId");

            migrationBuilder.CreateIndex(
                name: "IX_Groepsreizen_LeeftijdscategorieId",
                table: "Groepsreizen",
                column: "LeeftijdscategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Groepsreizen_ThemaId",
                table: "Groepsreizen",
                column: "ThemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_GebruikerId",
                table: "Inschrijvingen",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_GroepsreisId",
                table: "Inschrijvingen",
                column: "GroepsreisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inschrijvingen");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropTable(
                name: "Groepsreizen");

            migrationBuilder.DropTable(
                name: "Bestemmingen");

            migrationBuilder.DropTable(
                name: "Leeftijdscategorien");

            migrationBuilder.DropTable(
                name: "Themas");
        }
    }
}
