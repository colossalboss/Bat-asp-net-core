using System;
using _9jaTips.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _9jaTips.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)   
        {
        }

        public DbSet<Post> AllPosts { get; set; }

        public DbSet<Match> AllMatches { get; set; }

        public DbSet<Comment> AllComments { get; set; }

        public DbSet<Like> AllLikes { get; set; }
    }
}
