using System;
using System.Collections.Generic;

namespace _9jaTips.Entities
{
    public class CommentDto
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }

        public string Message { get; set; }

        public string TimeStamp { get; set; }

        public Guid UserId { get; set; }

        public string Username { get; set; }

        public List<string> Streak { get; set; }

        public string Image { get; set; }

    }
}
