using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjektZespolowy.Migrations
{
    public partial class appuserObjectCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DostepDoMonitoringu",
                table: "Podmioty",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PodmiotId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DostepDoMonitoringu",
                table: "Podmioty");

            migrationBuilder.DropColumn(
                name: "PodmiotId",
                table: "AspNetUsers");
        }
    }
}
