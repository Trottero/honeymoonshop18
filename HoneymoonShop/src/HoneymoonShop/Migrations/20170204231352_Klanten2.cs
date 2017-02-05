using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HoneymoonShop.Migrations
{
    public partial class Klanten2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klanten2",
                columns: table => new
                {
                    KlantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Emailadres = table.Column<string>(nullable: true),
                    Naam = table.Column<string>(nullable: true),
                    Telefoonnummer = table.Column<int>(nullable: false),
                    Trouwdatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten2", x => x.KlantID);
                });

            migrationBuilder.CreateTable(
                name: "afspraken2",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    KlantID = table.Column<int>(nullable: false),
                    Tijd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_afspraken2", x => x.ID);
                    table.ForeignKey(
                        name: "FK_afspraken2_Klanten2_KlantID",
                        column: x => x.KlantID,
                        principalTable: "Klanten2",
                        principalColumn: "KlantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_afspraken2_KlantID",
                table: "afspraken2",
                column: "KlantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "afspraken2");

            migrationBuilder.DropTable(
                name: "Klanten2");
        }
    }
}
