using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjektZespolowy.Migrations
{
    public partial class eee1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rachunki_Podmioty_KlientPodmiotId",
                table: "Rachunki");

            migrationBuilder.RenameColumn(
                name: "KlientPodmiotId",
                table: "Rachunki",
                newName: "PodmiotId");

            migrationBuilder.RenameIndex(
                name: "IX_Rachunki_KlientPodmiotId",
                table: "Rachunki",
                newName: "IX_Rachunki_PodmiotId");

            migrationBuilder.AddColumn<string>(
                name: "KlientId",
                table: "Rachunki",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNaturalPerson",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nip",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pesel",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Regon",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rachunki_KlientId",
                table: "Rachunki",
                column: "KlientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rachunki_AspNetUsers_KlientId",
                table: "Rachunki",
                column: "KlientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rachunki_Podmioty_PodmiotId",
                table: "Rachunki",
                column: "PodmiotId",
                principalTable: "Podmioty",
                principalColumn: "PodmiotId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rachunki_AspNetUsers_KlientId",
                table: "Rachunki");

            migrationBuilder.DropForeignKey(
                name: "FK_Rachunki_Podmioty_PodmiotId",
                table: "Rachunki");

            migrationBuilder.DropIndex(
                name: "IX_Rachunki_KlientId",
                table: "Rachunki");

            migrationBuilder.DropColumn(
                name: "KlientId",
                table: "Rachunki");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsNaturalPerson",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nip",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Regon",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PodmiotId",
                table: "Rachunki",
                newName: "KlientPodmiotId");

            migrationBuilder.RenameIndex(
                name: "IX_Rachunki_PodmiotId",
                table: "Rachunki",
                newName: "IX_Rachunki_KlientPodmiotId");

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
