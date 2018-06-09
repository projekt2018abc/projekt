using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjektZespolowy.Migrations
{
    public partial class m11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Podmioty_PodmiotId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rachunki_Podmioty_KlientPodmiotId",
                table: "Rachunki");

            migrationBuilder.DropTable(
                name: "Podmioty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pracownicy",
                table: "Pracownicy");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PodmiotId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PodmiotId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Pracownicy",
                newName: "Podmioty");

            migrationBuilder.RenameColumn(
                name: "PracownikId",
                table: "Podmioty",
                newName: "PodmiotId");

            migrationBuilder.AddColumn<string>(
                name: "Nip",
                table: "Podmioty",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Haslo_hashed",
                table: "Podmioty",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Podmioty",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ilosc_punktow",
                table: "Podmioty",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imie",
                table: "Podmioty",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nazwisko",
                table: "Podmioty",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pesel",
                table: "Podmioty",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Podmioty",
                table: "Podmioty",
                column: "PodmiotId");

            migrationBuilder.CreateIndex(
                name: "IX_Podmioty_AdresId",
                table: "Podmioty",
                column: "AdresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Podmioty_Adresy_AdresId",
                table: "Podmioty",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "AdresId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rachunki_Podmioty_KlientPodmiotId",
                table: "Rachunki",
                column: "KlientPodmiotId",
                principalTable: "Podmioty",
                principalColumn: "PodmiotId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Podmioty_Adresy_AdresId",
                table: "Podmioty");

            migrationBuilder.DropForeignKey(
                name: "FK_Rachunki_Podmioty_KlientPodmiotId",
                table: "Rachunki");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Podmioty",
                table: "Podmioty");

            migrationBuilder.DropIndex(
                name: "IX_Podmioty_AdresId",
                table: "Podmioty");

            migrationBuilder.DropColumn(
                name: "Nip",
                table: "Podmioty");

            migrationBuilder.DropColumn(
                name: "Haslo_hashed",
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

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Podmioty");

            migrationBuilder.DropColumn(
                name: "Ilosc_punktow",
                table: "Podmioty");

            migrationBuilder.DropColumn(
                name: "Imie",
                table: "Podmioty");

            migrationBuilder.DropColumn(
                name: "Nazwisko",
                table: "Podmioty");

            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "Podmioty");

            migrationBuilder.RenameTable(
                name: "Podmioty",
                newName: "Pracownicy");

            migrationBuilder.RenameColumn(
                name: "PodmiotId",
                table: "Pracownicy",
                newName: "PracownikId");

            migrationBuilder.AddColumn<int>(
                name: "PodmiotId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pracownicy",
                table: "Pracownicy",
                column: "PracownikId");

            migrationBuilder.CreateTable(
                name: "Podmioty",
                columns: table => new
                {
                    Nip = table.Column<string>(nullable: true),
                    Haslo_hashed = table.Column<string>(nullable: true),
                    Nazwa = table.Column<string>(nullable: true),
                    Regon = table.Column<string>(nullable: true),
                    PodmiotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdresId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Ilosc_punktow = table.Column<int>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PodmiotId",
                table: "AspNetUsers",
                column: "PodmiotId");

            migrationBuilder.CreateIndex(
                name: "IX_Podmioty_AdresId",
                table: "Podmioty",
                column: "AdresId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Podmioty_PodmiotId",
                table: "AspNetUsers",
                column: "PodmiotId",
                principalTable: "Podmioty",
                principalColumn: "PodmiotId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rachunki_Podmioty_KlientPodmiotId",
                table: "Rachunki",
                column: "KlientPodmiotId",
                principalTable: "Podmioty",
                principalColumn: "PodmiotId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
