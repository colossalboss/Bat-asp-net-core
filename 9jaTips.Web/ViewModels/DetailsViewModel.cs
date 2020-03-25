using System;
using _9jaTips.Entities;

namespace _9jaTips.Web.ViewModels
{
    public class DetailsViewModel : Post
    {
        public DetailsViewModel()
        {
        }

        public string TimeStamp { get; set; }

        public string Location { get; set; }

        public string Prediction { get; set; }

        public string Message { get; set; }
    }
}
