using System;
using System.Collections.Generic;
using _9jaTips.Entities;

namespace _9jaTips.Services.Interfaces
{
    public interface IFixtures
    {
        List<string> GetCountries();
        List<string> GetLeagues(string country);
        List<Match> GetFixtures(string country, string league);
        Match GetMatchById(int id);
        Post AddPost(Post post);
        List<Post> GetAllPosts();
    }
}
