using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CourseProject.Data.Migrations
{
    public partial class ConspectTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConspectTag_Conspects_ConspectId",
                table: "ConspectTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ConspectTag_Tags_TagId",
                table: "ConspectTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConspectTag",
                table: "ConspectTag");

            migrationBuilder.RenameTable(
                name: "ConspectTag",
                newName: "ConspectTags");

            migrationBuilder.RenameIndex(
                name: "IX_ConspectTag_TagId",
                table: "ConspectTags",
                newName: "IX_ConspectTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConspectTags",
                table: "ConspectTags",
                columns: new[] { "ConspectId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConspectTags_Conspects_ConspectId",
                table: "ConspectTags",
                column: "ConspectId",
                principalTable: "Conspects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConspectTags_Tags_TagId",
                table: "ConspectTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConspectTags_Conspects_ConspectId",
                table: "ConspectTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ConspectTags_Tags_TagId",
                table: "ConspectTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConspectTags",
                table: "ConspectTags");

            migrationBuilder.RenameTable(
                name: "ConspectTags",
                newName: "ConspectTag");

            migrationBuilder.RenameIndex(
                name: "IX_ConspectTags_TagId",
                table: "ConspectTag",
                newName: "IX_ConspectTag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConspectTag",
                table: "ConspectTag",
                columns: new[] { "ConspectId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConspectTag_Conspects_ConspectId",
                table: "ConspectTag",
                column: "ConspectId",
                principalTable: "Conspects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConspectTag_Tags_TagId",
                table: "ConspectTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
