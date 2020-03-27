using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace _9jaTips.Web.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfrimPassword { get; set; }

        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
