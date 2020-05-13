using System;
using System.Collections.Generic;

namespace _9jaTips.Entities
{
    public class PostDetailsDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Username { get; set; }

        public List<string> Streak { get; set; }

        public Match Match { get; set; }

        public string Tip { get; set; }

        public string Thoughts { get; set; }

        public List<Like> Likes { get; set; }

        public List<CommentDto> Comments { get; set; }

        public string TimeStamp { get; set; }
    }
}
