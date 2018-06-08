using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication6.Data.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Osoby_OsobaId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Osoby",
                table: "Osoby");

            migrationBuilder.RenameTable(
                name: "Osoby",
                newName: "Podmioty");

            migrationBuilder.RenameColumn(
                name: "nip",
                table: "Podmioty",
                newName: "Nip");

            migrationBuilder.RenameColumn(
                name: "ilosc_punktow",
                table: "Podmioty",
                newName: "Ilosc_punktow");

            migrationBuilder.RenameColumn(
                name: "OsobaId",
                table: "Podmioty",
                newName: "PodmiotId");

            migrationBuilder.RenameColumn(
                name: "OsobaId",
                table: "AspNetUsers",
                newName: "osobaPodmiotId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_OsobaId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_osobaPodmiotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Podmioty",
                table: "Podmioty",
                column: "PodmiotId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Podmioty_osobaPodmiotId",
                table: "AspNetUsers",
                column: "osobaPodmiotId",
                principalTable: "Podmioty",
                principalColumn: "PodmiotId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Podmioty_osobaPodmiotId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Podmioty",
                table: "Podmioty");

            migrationBuilder.RenameTable(
                name: "Podmioty",
                newName: "Osoby");

            migrationBuilder.RenameColumn(
                name: "Nip",
                table: "Osoby",
                newName: "nip");

            migrationBuilder.RenameColumn(
                name: "Ilosc_punktow",
                table: "Osoby",
                newName: "ilosc_punktow");

            migrationBuilder.RenameColumn(
                name: "PodmiotId",
                table: "Osoby",
                newName: "OsobaId");

            migrationBuilder.RenameColumn(
                name: "osobaPodmiotId",
                table: "AspNetUsers",
                newName: "OsobaId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_osobaPodmiotId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_OsobaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Osoby",
                table: "Osoby",
                column: "OsobaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Osoby_OsobaId",
                table: "AspNetUsers",
                column: "OsobaId",
                principalTable: "Osoby",
                principalColumn: "OsobaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
