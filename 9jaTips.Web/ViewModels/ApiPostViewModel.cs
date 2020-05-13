using System;
using System.Collections.Generic;
using _9jaTips.Entities;

namespace _9jaTips.Web.ViewModels
{
    public class ApiPostViewModel
    {
        public ApiPostViewModel()
        {

        }

        public Guid PostId { get; set; }

        public AppUser User { get; set; }

        public List<string> Streak { get; set; }

        public Match Match { get; set; }

        public string Tip { get; set; }

        public string Thoughts { get; set; }

        public List<Like> Likes { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
