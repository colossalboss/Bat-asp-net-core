using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _9jaTips.Entities
{
    public class Post
    {
        public Post()
        {
        }

        public Guid Id { get; set; }

        [Required]
        public Guid AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        public string Tip { get; set; }

        public DateTime PostDate { get; set; }

        public string Thoughts { get; set; }

        public string Outcome { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
