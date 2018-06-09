using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjektZespolowy.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Podmioty_osobaPodmiotId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "osobaPodmiotId",
                table: "AspNetUsers",
                newName: "PodmiotId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_osobaPodmiotId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_PodmiotId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Podmioty_PodmiotId",
                table: "AspNetUsers",
                column: "PodmiotId",
                principalTable: "Podmioty",
                principalColumn: "PodmiotId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Podmioty_PodmiotId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PodmiotId",
                table: "AspNetUsers",
                newName: "osobaPodmiotId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_PodmiotId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_osobaPodmiotId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Podmioty_osobaPodmiotId",
                table: "AspNetUsers",
                column: "osobaPodmiotId",
                principalTable: "Podmioty",
                principalColumn: "PodmiotId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
