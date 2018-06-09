using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication6.Data.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nazwa",
                table: "Podmioty",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Regon",
                table: "Podmioty",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "Podmioty",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Adresy",
                columns: table => new
                {
                    AdresId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kod_pocztowy = table.Column<string>(nullable: true),
                    Miejscowosc = table.Column<string>(nullable: true),
                    Numer_domu = table.Column<string>(nullable: true),
                    Numer_lokalu = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresy", x => x.AdresId);
                });

            migrationBuilder.CreateTable(
                name: "Faktury",
                columns: table => new
                {
                    FakturaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faktury", x => x.FakturaId);
                });

            migrationBuilder.CreateTable(
                name: "Powiadomienia",
                columns: table => new
                {
                    PowiadomienieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powiadomienia", x => x.PowiadomienieId);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    PracownikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Stanowisko = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.PracownikId);
                });

            migrationBuilder.CreateTable(
                name: "Rachunki",
                columns: table => new
                {
                    RachunekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    KlientPodmiotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rachunki", x => x.RachunekId);
                    table.ForeignKey(
                        name: "FK_Rachunki_Podmioty_KlientPodmiotId",
                        column: x => x.KlientPodmiotId,
                        principalTable: "Podmioty",
                        principalColumn: "PodmiotId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uslugi",
                columns: table => new
                {
                    UslugaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cena = table.Column<double>(nullable: false),
                    PunktyKoszt = table.Column<int>(nullable: false),
                    PunktyZysk = table.Column<int>(nullable: false),
                    TypUslugi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uslugi", x => x.UslugaId);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    RezerwacjaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    UslugaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.RezerwacjaId);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Uslugi_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Uslugi",
                        principalColumn: "UslugaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WykonaneUslugi",
                columns: table => new
                {
                    WykonanaUslugaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    DodanePunkty = table.Column<int>(nullable: false),
                    Ilosc = table.Column<double>(nullable: false),
                    IloscZaPunkty = table.Column<int>(nullable: false),
                    Koszt = table.Column<double>(nullable: false),
                    UslugaId = table.Column<int>(nullable: true),
                    WykorzystanePunkty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WykonaneUslugi", x => x.WykonanaUslugaId);
                    table.ForeignKey(
                        name: "FK_WykonaneUslugi_Uslugi_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Uslugi",
                        principalColumn: "UslugaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Podmioty_AdresId",
                table: "Podmioty",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Rachunki_KlientPodmiotId",
                table: "Rachunki",
                column: "KlientPodmiotId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_UslugaId",
                table: "Rezerwacje",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_WykonaneUslugi_UslugaId",
                table: "WykonaneUslugi",
                column: "UslugaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Podmioty_Adresy_AdresId",
                table: "Podmioty",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "AdresId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Podmioty_Adresy_AdresId",
                table: "Podmioty");

            migrationBuilder.DropTable(
                name: "Adresy");

            migrationBuilder.DropTable(
                name: "Faktury");

            migrationBuilder.DropTable(
                name: "Powiadomienia");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Rachunki");

            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "WykonaneUslugi");

            migrationBuilder.DropTable(
                name: "Uslugi");

            migrationBuilder.DropIndex(
                name: "IX_Podmioty_AdresId",
                table: "Podmioty");

            migrationBuilder.DropColumn(
                name: "Nazwa",
                table: "Podmioty");

            migrationBuilder.DropColumn(
                name: "Regon",
                table: "Podmioty");

            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "Podmioty");
        }
    }
}
