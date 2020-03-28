using System;
using System.Collections.Generic;
using System.Linq;
using _9jaTips.Data;
using _9jaTips.Entities;
using _9jaTips.Services.Interfaces;
using _9jaTips.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace _9jaTips.Services.Repositories
{
    public class FixturesRepository : IFixtures
    {
        private readonly AppDbContext _db;

        public FixturesRepository(AppDbContext db)
        {
            _db = db;
        }

        public Post AddPost(Post post)
        {
            _db.AllPosts.Add(post);
            _db.SaveChanges();
            return post;
        }

        public List<Post> GetAllPosts()
        {
            return _db.AllPosts.Include(p => p.Comments).ToList();
        }

        public List<Post> GetCountryPosts(string country)
        {
            var posts = _db.AllPosts.Include(p => p.Comments).ToList();
            var targetPosts = new List<Post>();
            foreach(var post in posts)
            {
                var match = _db.AllMatches.FirstOrDefault(m => m.MatchId == post.MatchId);
                if (match.Country == country)
                {
                    targetPosts.Add(post);
                }
            }
            return targetPosts;
        }

        public List<string> GetCountries()
        {
            var matches = _db.AllMatches.ToList();
            var countries = new List<string>();

            foreach (var match in matches)
            {
                if (!countries.Contains(match.Country))
                {
                    countries.Add(match.Country);
                }
            }
            return countries;
        }

        public List<Match> GetFixtures(string country, string league)
        {
            var matches = _db.AllMatches.Where(m => m.Country == country && m.League == league).ToList();
            return matches;
        }

        public List<string> GetLeagues(string country)
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

        public Match GetMatchById(int id)
        {
            return _db.AllMatches.FirstOrDefault(m => m.MatchId == id);
        }

        public Post GetOnePost(Guid id)
        {
            return _db.AllPosts.FirstOrDefault(p => p.Id == id);
        }

        public Post GetPostById(Guid id)
        {
            return _db.AllPosts.Include(p => p.Comments).Include(p => p.AppUser).FirstOrDefault(p => p.Id == id);
        }

        public List<Post> GetUsersPost(Guid id)
        {
            return _db.AllPosts.Where(p => p.AppUserId == id).Include(p => p.Comments).ToList();
        }



        // Comment
        public Comment AddComment(Comment comment)
        {
            _db.AllComments.Add(comment);
            _db.SaveChanges();
            return comment;
        }

        // Like
        public Like AddLike(Like like)
        {
            _db.AllLikes.Add(like);
            _db.SaveChanges();
            return like;
        }

        public int GetCount(Guid id)
        {
            return _db.AllLikes.Where(p => p.PostId == id).Count();
        }

        public Like HasLiked(Guid postId, Guid userId)
        {
            var like = _db.AllLikes.Where(l => l.PostId == postId && l.UserId == userId).ToList();
            return like.FirstOrDefault(p => p.PostId == postId);
        }

        public Like Unlike(Guid id, Guid userId)
        {
            var unliked = _db.AllLikes.FirstOrDefault(l => l.PostId == id && l.UserId == userId);
            _db.Remove(unliked);
            _db.SaveChanges();
            return unliked;
        }

    }
}
