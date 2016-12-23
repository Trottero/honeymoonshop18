using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneymoonShop.Migrations
{
    public partial class tablenameEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jurken_Merk_MerkID",
                table: "Jurken");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurken_Silhouette_SilhouetteID",
                table: "Jurken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Silhouette",
                table: "Silhouette");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Merk",
                table: "Merk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Silhouetten",
                table: "Silhouette",
                column: "SilhouetteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Merken",
                table: "Merk",
                column: "MerkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jurken_Merken_MerkID",
                table: "Jurken",
                column: "MerkID",
                principalTable: "Merk",
                principalColumn: "MerkID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurken_Silhouetten_SilhouetteID",
                table: "Jurken",
                column: "SilhouetteID",
                principalTable: "Silhouette",
                principalColumn: "SilhouetteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "Silhouette",
                newName: "Silhouetten");

            migrationBuilder.RenameTable(
                name: "Merk",
                newName: "Merken");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jurken_Merken_MerkID",
                table: "Jurken");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurken_Silhouetten_SilhouetteID",
                table: "Jurken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Silhouetten",
                table: "Silhouetten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Merken",
                table: "Merken");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Silhouette",
                table: "Silhouetten",
                column: "SilhouetteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Merk",
                table: "Merken",
                column: "MerkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jurken_Merk_MerkID",
                table: "Jurken",
                column: "MerkID",
                principalTable: "Merken",
                principalColumn: "MerkID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurken_Silhouette_SilhouetteID",
                table: "Jurken",
                column: "SilhouetteID",
                principalTable: "Silhouetten",
                principalColumn: "SilhouetteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "Silhouetten",
                newName: "Silhouette");

            migrationBuilder.RenameTable(
                name: "Merken",
                newName: "Merk");
        }
    }
}
