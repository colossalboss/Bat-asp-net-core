using System;
using _9jaTips.Entities;
using Microsoft.EntityFrameworkCore;

namespace _9jaTips.Data.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasData(
                    new Match
                    {
                        MatchId = 1,
                        Country = "England",
                        League = "Premier League",
                        Home = "Chelsea",
                        Away = "Man Utd",
                    },

                    new Match
                    {
                        MatchId = 2,
                        Country = "Spain",
                        League = "La Liga",
                        Home = "Barca",
                        Away = "Madrid",
                    },

                    new Match
                    {
                        MatchId = 3,
                        Country = "Italy",
                        League = "Serie A",
                        Home = "Juve",
                        Away = "Inter",
                    },

                    new Match
                    {
                        MatchId = 4,
                        Country = "Germany",
                        League = "Bundesliga",
                        Home = "Bayern",
                        Away = "Dortmund",
                    },

                    new Match
                    {
                        MatchId = 5,
                        Country = "France",
                        League = "Ligue 1",
                        Home = "PSG",
                        Away = "Lyon",
                    },

                    new Match
                    {
                        MatchId = 6,
                        Country = "England",
                        League = "FA Cup",
                        Home = "Arsenal",
                        Away = "Liverpool",
                    },

                    new Match
                    {
                        MatchId = 7,
                        Country = "Italy",
                        League = "Coppa Italia",
                        Home = "AC Milan",
                        Away = "Lazio",
                    }
                );
        }
    }
}
