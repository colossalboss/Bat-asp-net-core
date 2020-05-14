using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _9jaTips.Entities;
using _9jaTips.Services.Interfaces;
using _9jaTips.Web.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _9jaTips.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IFixtures _fixtures;

        public ProfileController(UserManager<AppUser> userManager, IFixtures fixture)
        {
            this.userManager = userManager;
            _fixtures = fixture;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            var viewerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (user.Id == viewerId)
            {
                ViewBag.editable = true;
            }
            else
            {
                ViewBag.editable = false;
            }

            var posts = _fixtures.GetUsersPost(id);

            var userStreak = _fixtures.GetUserStreak(id);

            var userPosts = new List<ListPostViewModel>();

            foreach(var post in posts)
            {
                var poster = await userManager.FindByIdAsync(post.AppUserId.ToString());
                var streak = _fixtures.GetUserStreak(post.AppUserId);

                var up = new ListPostViewModel
                {
                    PostDate = post.PostDate.Humanize(),
                    Comments = post.Comments,
                    Fixture = _fixtures.GetMatchById(post.MatchId),
                    Id = post.Id,
                    Image = poster.Image,
                    Thoughts = post.Thoughts,
                    Tip = post.Tip,
                    UserId = post.AppUserId,
                    Streak = streak
                };
                userPosts.Add(up);
            }

            ProfileDetailsViewModel model = new ProfileDetailsViewModel
            {
                User = user,
                Posts = userPosts,
                UserStreak = userStreak
            };

            if (user != null)
            {
                //Instantiate and return ProfileVM
                return View(model);
            }

            return NotFound();
        }
    }
}
