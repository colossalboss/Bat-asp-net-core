﻿using System;
using System.Collections.Generic;
using System.Linq;
using _9jaTips.Data;
using _9jaTips.Entities;
using _9jaTips.Services.Interfaces;
using _9jaTips.Services.Services;
using _9jaTips.Web.Utilities;
using AutoMapper;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace _9jaTips.Services.Repositories
{
    public class FixturesRepository : IFixtures
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public FixturesRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Post AddPost(Post post)
        {
            _db.AllPosts.Add(post);
            _db.SaveChanges();
            return post;
        }

        public List<Post> GetAllPosts()
        {
            return _db.AllPosts.Include(p => p.Comments).Include(p => p.Likes).ToList();
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
            var posts = _db.AllPosts.Where(p => p.AppUserId == id).Include(p => p.Comments).ToList();
            return posts.Reverse<Post>().ToList();
        }

        public List<string> GetUserStreak(Guid id)
        {
            var userPosts = _db.AllPosts.Where(p => p.AppUserId == id);
            var list = new List<string>();

            foreach(var post in userPosts)
            {
                list.Add(post.Outcome);
            }

            if (list.Count > 8)
            {
                return list.Reverse<string>().ToList().GetRange(0, 8);
            }
            return list.Reverse<string>().ToList();

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

        //API
        public List<PostItem> GetPostItems()
        {
            var posts = _db.AllPosts.Include(p => p.Comments)
                        .Include(p => p.Likes).ToList();

            posts.Sort((x, y) => DateTime.Compare(y.PostDate, x.PostDate));


            var resources = _mapper.Map<List<PostItem>>(posts);

            for (var i = 0; i < resources.Count; i++)
            {
                resources[i] = TransformPost(posts[i], resources[i]);
            }

            return resources;
        }

        private PostItem TransformPost(Post p, PostItem pi)
        {
            var postItem = pi;
            postItem.Comments = p.Comments.Count;
            postItem.Likes = p.Likes.Count;
            postItem.Streak = GetUserStreak(p.AppUserId);
            postItem.Match = GetMatchById(p.MatchId);
            postItem.TimeStamp = p.PostDate.Humanize();

            return postItem;
        }

        private CommentDto TransformCommentToCommentDto(Comment c, CommentDto cd)
        {
            //var commentDto = cd;
            cd.Streak = GetUserStreak(c.AppUserId);
            cd.TimeStamp = c.TimeStamp.Humanize();

            return cd;
        }

        private PostItem ConvertToPostItem(Post p)
        {
            var postItem = _mapper.Map<PostItem>(p);
            postItem.TimeStamp = p.PostDate.Humanize();
            postItem.Streak = GetUserStreak(p.AppUserId);
            postItem.Match = GetMatchById(p.MatchId);
            postItem.Likes = p.Likes.Count;
            postItem.Comments = p.Comments.Count;
            return postItem;
        }

        public PostItem GetPostItemById(Guid id)
        {
            var postItem = _db.AllPosts.Include(p => p.Comments)
                        .Include(p => p.Likes)
                        .FirstOrDefault(p => p.Id == id);

            return ConvertToPostItem(postItem);
        }

        public List<CommentDto> GetPostComments(Guid id)
        {
            var comments = _db.AllComments.Where(c => c.PostId == id).ToList();
            comments.Sort((x, y) => DateTime.Compare(y.TimeStamp, x.TimeStamp));

            var commentDtos = _mapper.Map<List<CommentDto>>(comments);

            for(var i = 0; i < commentDtos.Count; i++)
            {
                commentDtos[i] = TransformCommentToCommentDto(comments[i], commentDtos[i]);
            }
            return commentDtos;
        }

        public Post DeletePost(Guid id)
        {
            var post = _db.AllPosts.FirstOrDefault(p => p.Id == id);

            if (post != null)
            {
                _db.AllPosts.Remove(post);
                _db.SaveChanges();
            }
            return post;
        }

        public Comment DeleteComment(Guid id)
        {
            var comment = _db.AllComments.FirstOrDefault(c => c.Id == id);

            if (comment != null)
            {
                _db.AllComments.Remove(comment);
                _db.SaveChanges();
            }
            return comment;
        }
    }
}
