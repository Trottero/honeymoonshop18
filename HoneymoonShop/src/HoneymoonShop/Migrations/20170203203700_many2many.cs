using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneymoonShop.Migrations
{
    public partial class many2many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jurken_Kleuren_KleurID",
                table: "Jurken");

            migrationBuilder.DropIndex(
                name: "IX_Jurken_KleurID",
                table: "Jurken");

            migrationBuilder.DropColumn(
                name: "KleurID",
                table: "Jurken");

            migrationBuilder.CreateTable(
                name: "JurkKleur",
                columns: table => new
                {
                    JurkID = table.Column<int>(nullable: false),
                    KleurID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JurkKleur", x => new { x.JurkID, x.KleurID });
                    table.ForeignKey(
                        name: "FK_JurkKleur_Jurken_JurkID",
                        column: x => x.JurkID,
                        principalTable: "Jurken",
                        principalColumn: "JurkID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JurkKleur_Kleuren_KleurID",
                        column: x => x.KleurID,
                        principalTable: "Kleuren",
                        principalColumn: "KleurID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JurkKleur_JurkID",
                table: "JurkKleur",
                column: "JurkID");

            migrationBuilder.CreateIndex(
                name: "IX_JurkKleur_KleurID",
                table: "JurkKleur",
                column: "KleurID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JurkKleur");

            migrationBuilder.AddColumn<int>(
                name: "KleurID",
                table: "Jurken",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jurken_KleurID",
                table: "Jurken",
                column: "KleurID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jurken_Kleuren_KleurID",
                table: "Jurken",
                column: "KleurID",
                principalTable: "Kleuren",
                principalColumn: "KleurID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
