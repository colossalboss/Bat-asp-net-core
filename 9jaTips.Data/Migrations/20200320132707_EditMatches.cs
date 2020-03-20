using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _9jaTips.Data.Migrations
{
    public partial class EditMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AllMatches",
                table: "AllMatches");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AllMatches");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "AllMatches",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllMatches",
                table: "AllMatches",
                column: "MatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AllMatches",
                table: "AllMatches");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "AllMatches");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AllMatches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllMatches",
                table: "AllMatches",
                column: "Id");
        }
    }
}
