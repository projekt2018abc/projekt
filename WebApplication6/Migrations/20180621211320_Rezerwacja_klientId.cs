using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjektZespolowy.Migrations
{
    public partial class Rezerwacja_klientId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_AspNetUsers_KlientId",
                table: "Rezerwacje");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacje_KlientId",
                table: "Rezerwacje");

            migrationBuilder.AlterColumn<string>(
                name: "KlientId",
                table: "Rezerwacje",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KlientId",
                table: "Rezerwacje",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_KlientId",
                table: "Rezerwacje",
                column: "KlientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_AspNetUsers_KlientId",
                table: "Rezerwacje",
                column: "KlientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
