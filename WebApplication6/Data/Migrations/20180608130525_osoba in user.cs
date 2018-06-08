using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication6.Data.Migrations
{
    public partial class osobainuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OsobaId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Osoby",
                columns: table => new
                {
                    ilosc_punktow = table.Column<int>(nullable: true),
                    nip = table.Column<string>(nullable: true),
                    OsobaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppUserId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Haslo_hashed = table.Column<string>(nullable: true),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    Pesel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoby", x => x.OsobaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OsobaId",
                table: "AspNetUsers",
                column: "OsobaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Osoby_OsobaId",
                table: "AspNetUsers",
                column: "OsobaId",
                principalTable: "Osoby",
                principalColumn: "OsobaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Osoby_OsobaId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Osoby");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OsobaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OsobaId",
                table: "AspNetUsers");
        }
    }
}
