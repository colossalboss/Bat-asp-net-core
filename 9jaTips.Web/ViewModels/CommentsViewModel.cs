﻿using System;
using System.Collections.Generic;
using _9jaTips.Entities;

namespace _9jaTips.Web.ViewModels
{
    public class CommentsViewModel : Comment
    {
        public CommentsViewModel()
        {
        }

        public string Time { get; set; }

        public string UserImage { get; set; }

        public List<string> Streak { get; set; }
    }
}
