using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneymoonShop.Data.Migrations
{
    public partial class Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AfbeeldingUrl",
                table: "BruidsJurken",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Omschrijving",
                table: "BruidsJurken",
                maxLength: 300,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfbeeldingUrl",
                table: "BruidsJurken");

            migrationBuilder.AlterColumn<string>(
                name: "Omschrijving",
                table: "BruidsJurken",
                nullable: false);
        }
    }
}
