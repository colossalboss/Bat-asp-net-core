using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9jaTips.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _9jaTips.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            if (user != null)
            {
                //Instantiate and return ProfileVM
                return View(user);
            }

            return NotFound();
        }




    }
}
