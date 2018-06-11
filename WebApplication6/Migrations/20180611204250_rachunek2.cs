using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjektZespolowy.Migrations
{
    public partial class rachunek2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "zaksiegowano",
                table: "WykonaneUslugi",
                newName: "Zaksiegowano");

            migrationBuilder.AddColumn<int>(
                name: "StanowiskoId",
                table: "WykonaneUslugi",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StanowiskoId",
                table: "Uslugi",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stanowisko",
                columns: table => new
                {
                    StanowiskoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Typ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanowisko", x => x.StanowiskoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WykonaneUslugi_StanowiskoId",
                table: "WykonaneUslugi",
                column: "StanowiskoId");

            migrationBuilder.CreateIndex(
                name: "IX_Uslugi_StanowiskoId",
                table: "Uslugi",
                column: "StanowiskoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uslugi_Stanowisko_StanowiskoId",
                table: "Uslugi",
                column: "StanowiskoId",
                principalTable: "Stanowisko",
                principalColumn: "StanowiskoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WykonaneUslugi_Stanowisko_StanowiskoId",
                table: "WykonaneUslugi",
                column: "StanowiskoId",
                principalTable: "Stanowisko",
                principalColumn: "StanowiskoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uslugi_Stanowisko_StanowiskoId",
                table: "Uslugi");

            migrationBuilder.DropForeignKey(
                name: "FK_WykonaneUslugi_Stanowisko_StanowiskoId",
                table: "WykonaneUslugi");

            migrationBuilder.DropTable(
                name: "Stanowisko");

            migrationBuilder.DropIndex(
                name: "IX_WykonaneUslugi_StanowiskoId",
                table: "WykonaneUslugi");

            migrationBuilder.DropIndex(
                name: "IX_Uslugi_StanowiskoId",
                table: "Uslugi");

            migrationBuilder.DropColumn(
                name: "StanowiskoId",
                table: "WykonaneUslugi");

            migrationBuilder.DropColumn(
                name: "StanowiskoId",
                table: "Uslugi");

            migrationBuilder.RenameColumn(
                name: "Zaksiegowano",
                table: "WykonaneUslugi",
                newName: "zaksiegowano");
        }
    }
}
