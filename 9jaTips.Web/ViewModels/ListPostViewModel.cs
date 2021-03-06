﻿using System;
using System.Collections.Generic;
using _9jaTips.Entities;

namespace _9jaTips.Web.ViewModels
{
    public class ListPostViewModel
    {
        public Guid Id { get; set; }

        public Match Fixture { get; set; }

        public String Tip { get; set; }

        public String Thoughts { get; set; }

        public Guid UserId { get; set; }

        public string PostDate { get; set; }

        public string Image { get; set; }

        public List<Comment> Comments { get; set; }
        public List<string> Streak { get; set; }
    }
}
