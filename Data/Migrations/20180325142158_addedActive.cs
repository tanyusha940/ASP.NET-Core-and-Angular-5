using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CourseProject.Data.Migrations
{
    public partial class addedActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Comments",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Tags",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Ratings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Comments",
                newName: "CreateDate");
        }
    }
}
