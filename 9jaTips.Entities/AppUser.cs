using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace _9jaTips.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
        }

        public List<Post> Posts { get; set; }
    }
}
