using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjektZespolowy.Migrations
{
    public partial class monitoring_rezerwacje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Powiadomienia_Monitoring_monitoringId",
                table: "Powiadomienia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Monitoring",
                table: "Monitoring");

            migrationBuilder.RenameTable(
                name: "Monitoring",
                newName: "Monitorings");

            migrationBuilder.AddColumn<string>(
                name: "KlientId",
                table: "Rezerwacje",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Monitorings",
                table: "Monitorings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_KlientId",
                table: "Rezerwacje",
                column: "KlientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Powiadomienia_Monitorings_monitoringId",
                table: "Powiadomienia",
                column: "monitoringId",
                principalTable: "Monitorings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_AspNetUsers_KlientId",
                table: "Rezerwacje",
                column: "KlientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Powiadomienia_Monitorings_monitoringId",
                table: "Powiadomienia");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_AspNetUsers_KlientId",
                table: "Rezerwacje");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacje_KlientId",
                table: "Rezerwacje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Monitorings",
                table: "Monitorings");

            migrationBuilder.DropColumn(
                name: "KlientId",
                table: "Rezerwacje");

            migrationBuilder.RenameTable(
                name: "Monitorings",
                newName: "Monitoring");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Monitoring",
                table: "Monitoring",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Powiadomienia_Monitoring_monitoringId",
                table: "Powiadomienia",
                column: "monitoringId",
                principalTable: "Monitoring",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
