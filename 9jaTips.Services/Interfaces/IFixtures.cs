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
        List<string> GetUserStreak(Guid id);

        Post GetOnePost(Guid id);
        Post AddPost(Post post);
        List<Post> GetAllPosts();
        List<Post> GetCountryPosts(string country);
        Post DeletePost(Guid id);

        

        Comment AddComment(Comment comment);
        Comment DeleteComment(Guid id);

        Like AddLike(Like like);
        Like Unlike(Guid id, Guid userId);

        int GetCount(Guid id);

        Like HasLiked(Guid postId, Guid userId);

        //API
        List<PostItem> GetPostItems();
        PostItem GetPostItemById(Guid Id);

        List<CommentDto> GetPostComments(Guid id);

    }
}
