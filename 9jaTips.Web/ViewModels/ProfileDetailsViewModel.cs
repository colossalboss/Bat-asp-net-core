using System;
using System.Collections.Generic;
using _9jaTips.Entities;

namespace _9jaTips.Web.ViewModels
{
    public class ProfileDetailsViewModel
    {
        public ProfileDetailsViewModel()
        {
        }

        public AppUser User { get; set; }

        public List<string> UserStreak { get; set; }

        public List<ListPostViewModel> Posts { get; set; }
    }
}
