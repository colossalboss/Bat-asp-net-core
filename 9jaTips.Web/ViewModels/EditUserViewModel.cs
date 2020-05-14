using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace _9jaTips.Web.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
        }

        [Required]
        public string Email { get; set; }

        //[Required]
        //public string Password { get; set; }

        public IFormFile NewImage { get; set; }

        public string ExistingImage { get; set; }
    }
}
