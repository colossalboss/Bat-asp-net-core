using System;
using System.ComponentModel.DataAnnotations;

namespace _9jaTips.Web.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
