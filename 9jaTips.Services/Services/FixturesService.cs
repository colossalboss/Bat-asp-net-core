using System;
using System.Collections.Generic;
using System.Linq;
using _9jaTips.Data;
using _9jaTips.Services.Interfaces;
using _9jaTips.Services.Repositories;

namespace _9jaTips.Services.Services
{
    public class FixturesService
    {
        private readonly AppDbContext _db;
        private readonly FixturesRepository _fixturesRepository;

        public FixturesService(AppDbContext db, FixturesRepository fixturesRepository)
        {
            _db = db;
            _fixturesRepository = fixturesRepository;
        }

        public List<string> GetAvailableCountries()
        {
            var matches = _db.AllMatches.ToList();
            var countries = new List<string>();

            foreach(var match in matches)
            {
                if (!countries.Contains(match.Country))
                {
                    countries.Add(match.Country);
                }
            }
            return countries;
        }

        public List<string> GetAvailableLeagues(string country)
        {
            var matches = _db.AllMatches.ToList();
            var leagues = new List<string>();

            foreach (var match in matches)
            {
                if (match.Country == country && !leagues.Contains(match.League))
                {
                    leagues.Add(match.League);
                }
            }
            return leagues;
        }
    }
}
