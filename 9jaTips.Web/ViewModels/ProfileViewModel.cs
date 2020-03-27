using System;
using System.Collections.Generic;
using _9jaTips.Entities;

namespace _9jaTips.Web.ViewModels
{
    public class ProfileViewModel : AppUser
    {
        public ProfileViewModel()
        {
        }

        public List<Post> UserPosts { get; set; }
    }
}
