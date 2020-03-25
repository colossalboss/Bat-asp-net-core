using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _9jaTips.Data.Migrations
{
    public partial class UpdateLikeProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "AllLikes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AllLikes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostId",
                table: "AllLikes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AllLikes");
        }
    }
}
