using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneymoonShop.Migrations
{
    public partial class inist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_afspraken2_Klanten2_KlantID",
                table: "afspraken2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_afspraken2",
                table: "afspraken2");

            migrationBuilder.AlterColumn<string>(
                name: "Tijd",
                table: "afspraken2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Afspraken2",
                table: "afspraken2",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Afspraken2_Klanten2_KlantID",
                table: "afspraken2",
                column: "KlantID",
                principalTable: "Klanten2",
                principalColumn: "KlantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_afspraken2_KlantID",
                table: "afspraken2",
                newName: "IX_Afspraken2_KlantID");

            migrationBuilder.RenameTable(
                name: "afspraken2",
                newName: "Afspraken2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afspraken2_Klanten2_KlantID",
                table: "Afspraken2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Afspraken2",
                table: "Afspraken2");

            migrationBuilder.AlterColumn<int>(
                name: "Tijd",
                table: "Afspraken2",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_afspraken2",
                table: "Afspraken2",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_afspraken2_Klanten2_KlantID",
                table: "Afspraken2",
                column: "KlantID",
                principalTable: "Klanten2",
                principalColumn: "KlantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_Afspraken2_KlantID",
                table: "Afspraken2",
                newName: "IX_afspraken2_KlantID");

            migrationBuilder.RenameTable(
                name: "Afspraken2",
                newName: "afspraken2");
        }
    }
}
