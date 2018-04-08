using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CourseProject.Data.Migrations
{
    public partial class identityUser_TO_conspect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Conspects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserUserIdentityId",
                table: "Conspects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conspects_UserId1",
                table: "Conspects",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Conspects_AspNetUsers_UserId1",
                table: "Conspects",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conspects_AspNetUsers_UserId1",
                table: "Conspects");

            migrationBuilder.DropIndex(
                name: "IX_Conspects_UserId1",
                table: "Conspects");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Conspects");

            migrationBuilder.DropColumn(
                name: "UserUserIdentityId",
                table: "Conspects");
        }
    }
}
