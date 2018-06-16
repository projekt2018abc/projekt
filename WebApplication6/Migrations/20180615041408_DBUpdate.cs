using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjektZespolowy.Migrations
{
    public partial class DBUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rachunki");

            migrationBuilder.DropTable(
                name: "Podmioty");

            migrationBuilder.DropColumn(
                name: "PodmiotId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PodmiotId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Podmioty",
                columns: table => new
                {
                    Nip = table.Column<string>(nullable: true),
                    Nazwa = table.Column<string>(nullable: true),
                    Regon = table.Column<string>(nullable: true),
                    PodmiotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdresId = table.Column<int>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Ilosc_punktow = table.Column<int>(nullable: true),
                    DostepDoMonitoringu = table.Column<bool>(nullable: true),
                    Stanowisko = table.Column<string>(nullable: true),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    Pesel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podmioty", x => x.PodmiotId);
                    table.ForeignKey(
                        name: "FK_Podmioty_Adresy_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresy",
                        principalColumn: "AdresId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rachunki",
                columns: table => new
                {
                    RachunekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    FakturaId = table.Column<int>(nullable: true),
                    KlientPodmiotId = table.Column<int>(nullable: true),
                    Paragon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rachunki", x => x.RachunekId);
                    table.ForeignKey(
                        name: "FK_Rachunki_Faktury_FakturaId",
                        column: x => x.FakturaId,
                        principalTable: "Faktury",
                        principalColumn: "FakturaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rachunki_Podmioty_KlientPodmiotId",
                        column: x => x.KlientPodmiotId,
                        principalTable: "Podmioty",
                        principalColumn: "PodmiotId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Podmioty_AdresId",
                table: "Podmioty",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Rachunki_FakturaId",
                table: "Rachunki",
                column: "FakturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rachunki_KlientPodmiotId",
                table: "Rachunki",
                column: "KlientPodmiotId");
        }
    }
}
