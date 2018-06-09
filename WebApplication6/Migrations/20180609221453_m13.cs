using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjektZespolowy.Migrations
{
    public partial class m13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FakturaId",
                table: "Rachunki",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Paragon",
                table: "Rachunki",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rachunki_FakturaId",
                table: "Rachunki",
                column: "FakturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rachunki_Faktury_FakturaId",
                table: "Rachunki",
                column: "FakturaId",
                principalTable: "Faktury",
                principalColumn: "FakturaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rachunki_Faktury_FakturaId",
                table: "Rachunki");

            migrationBuilder.DropIndex(
                name: "IX_Rachunki_FakturaId",
                table: "Rachunki");

            migrationBuilder.DropColumn(
                name: "FakturaId",
                table: "Rachunki");

            migrationBuilder.DropColumn(
                name: "Paragon",
                table: "Rachunki");
        }
    }
}
