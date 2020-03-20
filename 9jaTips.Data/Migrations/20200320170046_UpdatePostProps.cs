using Microsoft.EntityFrameworkCore.Migrations;

namespace _9jaTips.Data.Migrations
{
    public partial class UpdatePostProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fixture",
                table: "AllPosts");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "AllPosts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "AllPosts");

            migrationBuilder.AddColumn<string>(
                name: "Fixture",
                table: "AllPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
