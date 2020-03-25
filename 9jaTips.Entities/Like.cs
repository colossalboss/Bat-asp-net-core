using System;
namespace _9jaTips.Entities
{
    public class Like
    {
        public Like()
        {
        }

        public Guid Id { get; set; }

        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

    }
}
