using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjektZespolowy.Migrations
{
    public partial class Rezerwacja_usluga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Uslugi_UslugaId",
                table: "Rezerwacje");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacje_UslugaId",
                table: "Rezerwacje");

            migrationBuilder.DropColumn(
                name: "UslugaId",
                table: "Rezerwacje");

            migrationBuilder.AddColumn<string>(
                name: "usluga",
                table: "Rezerwacje",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usluga",
                table: "Rezerwacje");

            migrationBuilder.AddColumn<int>(
                name: "UslugaId",
                table: "Rezerwacje",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_UslugaId",
                table: "Rezerwacje",
                column: "UslugaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Uslugi_UslugaId",
                table: "Rezerwacje",
                column: "UslugaId",
                principalTable: "Uslugi",
                principalColumn: "UslugaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
