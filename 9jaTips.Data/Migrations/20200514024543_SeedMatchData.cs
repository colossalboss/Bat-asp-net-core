using Microsoft.EntityFrameworkCore.Migrations;

namespace _9jaTips.Data.Migrations
{
    public partial class SeedMatchData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AllMatches",
                columns: new[] { "MatchId", "Away", "Country", "Home", "League", "Result" },
                values: new object[,]
                {
                    { 1, "Man Utd", "England", "Chelsea", "Premier League", null },
                    { 2, "Madrid", "Spain", "Barca", "La Liga", null },
                    { 3, "Inter", "Italy", "Juve", "Serie A", null },
                    { 4, "Dortmund", "Germany", "Bayern", "Bundesliga", null },
                    { 5, "Lyon", "France", "PSG", "Ligue 1", null },
                    { 6, "Liverpool", "England", "Arsenal", "FA Cup", null },
                    { 7, "Lazio", "Italy", "AC Milan", "Coppa Italia", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AllMatches",
                keyColumn: "MatchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AllMatches",
                keyColumn: "MatchId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AllMatches",
                keyColumn: "MatchId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AllMatches",
                keyColumn: "MatchId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AllMatches",
                keyColumn: "MatchId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AllMatches",
                keyColumn: "MatchId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AllMatches",
                keyColumn: "MatchId",
                keyValue: 7);
        }
    }
}
