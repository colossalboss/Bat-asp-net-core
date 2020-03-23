using System;
namespace _9jaTips.Web.ViewModels
{
    public class AjaxPostViewModel
    {
        public AjaxPostViewModel()
        {
        }

        public Guid Id { get; set; }

        public string UserName { get; set; }

        public Guid UserId { get; set; }

        public string Location { get; set; }

        public string Tip { get; set; }

        public string Thoughts { get; set; }

        public string TimeStamp { get; set; }
    }
}
