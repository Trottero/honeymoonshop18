using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HoneymoonShop.Data.Migrations
{
    public partial class BruidsJurk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BruidsJurken",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtikelNr = table.Column<int>(nullable: false),
                    Merk = table.Column<string>(nullable: true),
                    Naam = table.Column<string>(maxLength: 60, nullable: false),
                    Omschrijving = table.Column<string>(nullable: false),
                    Prijs = table.Column<int>(nullable: false),
                    Stijl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BruidsJurken", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BruidsJurken");
        }
    }
}
