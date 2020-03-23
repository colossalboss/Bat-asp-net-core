using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9jaTips.Entities;
using _9jaTips.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _9jaTips.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IFixtures _fixture;

        public ProfileController(UserManager<AppUser> userManager, IFixtures fixture)
        {
            this.userManager = userManager;
            _fixture = fixture;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            var usersPost = _fixture.GetUsersPost(id);

            if (user != null)
            {
                //Instantiate and return ProfileVM
                user.Posts = usersPost;
                return View(user);
            }

            return NotFound();
        }




    }
}
