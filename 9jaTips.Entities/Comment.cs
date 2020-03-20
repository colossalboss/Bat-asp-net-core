using System;
using System.ComponentModel.DataAnnotations;

namespace _9jaTips.Entities
{
    public class Comment
    {
        public Comment()
        {
        }

        public Guid Id { get; set; }

        [Required]
        public Guid PostId { get; set; }

        public Post Post { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public Guid AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
