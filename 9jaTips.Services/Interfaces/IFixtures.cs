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

        Post GetPostById(Guid id);
        List<Post> GetUsersPost(Guid id);

        Post GetOnePost(Guid id);
        Post AddPost(Post post);
        List<Post> GetAllPosts();

        Comment AddComment(Comment comment);

        Like AddLike(Like like);

        int GetCount(Guid id);

        bool HasLiked(Guid postId, Guid userId);
    }
}
