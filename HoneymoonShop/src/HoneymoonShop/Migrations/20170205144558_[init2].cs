using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneymoonShop.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefoonnummer",
                table: "Klanten2",
                maxLength: 10,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Klanten2",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Emailadres",
                table: "Klanten2",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Tijd",
                table: "Afspraken2",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefoonnummer",
                table: "Klanten2",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Klanten2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Emailadres",
                table: "Klanten2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tijd",
                table: "Afspraken2",
                nullable: true);
        }
    }
}
