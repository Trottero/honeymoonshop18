using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneymoonShop.Migrations
{
    public partial class initt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Trouwdatum",
                table: "Klanten2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Datum",
                table: "Afspraken2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Trouwdatum",
                table: "Klanten2",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "Afspraken2",
                nullable: false);
        }
    }
}
