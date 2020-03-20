using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _9jaTips.Data.Migrations
{
    public partial class UpdatePostProps3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "AllPosts");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostDate",
                table: "AllPosts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostDate",
                table: "AllPosts");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "AllPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
