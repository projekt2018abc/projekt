using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjektZespolowy.Migrations
{
    public partial class rachunek1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RachunekId",
                table: "WykonaneUslugi",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "zaksiegowano",
                table: "WykonaneUslugi",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_WykonaneUslugi_RachunekId",
                table: "WykonaneUslugi",
                column: "RachunekId");

            migrationBuilder.AddForeignKey(
                name: "FK_WykonaneUslugi_Rachunki_RachunekId",
                table: "WykonaneUslugi",
                column: "RachunekId",
                principalTable: "Rachunki",
                principalColumn: "RachunekId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WykonaneUslugi_Rachunki_RachunekId",
                table: "WykonaneUslugi");

            migrationBuilder.DropIndex(
                name: "IX_WykonaneUslugi_RachunekId",
                table: "WykonaneUslugi");

            migrationBuilder.DropColumn(
                name: "RachunekId",
                table: "WykonaneUslugi");

            migrationBuilder.DropColumn(
                name: "zaksiegowano",
                table: "WykonaneUslugi");
        }
    }
}
