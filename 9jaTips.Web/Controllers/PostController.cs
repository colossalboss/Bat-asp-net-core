using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _9jaTips.Entities;
using _9jaTips.Services.Interfaces;
using _9jaTips.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _9jaTips.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IFixtures _fixtures;
        private readonly UserManager<AppUser> userManager;

        public PostController(IFixtures fixtures, UserManager<AppUser> userManager)
        {
            _fixtures = fixtures;
            this.userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var posts = _fixtures.GetAllPosts();

            var modelList = new List<ListPostViewModel>();

            foreach(var post in posts)
            {
                var model = new ListPostViewModel
                {
                    Fixture = _fixtures.GetMatchById(post.MatchId),
                    Id = post.Id,
                    Thoughts = post.Thoughts,
                    Tip = post.Tip,
                    UserId = post.AppUserId
                };
                modelList.Add(model);
            }
            return View(modelList);
        }

        public IActionResult Countries()
        {
            ViewBag.Countries = _fixtures.GetCountries();
            return View();
        }

        public IActionResult Leagues(string country)
        {
            ViewBag.Leagues = _fixtures.GetLeagues(country);

            ViewBag.Country = country;
            return View();
        }

        public IActionResult Fixtures(string country, string league)
        {
            var matches = _fixtures.GetFixtures(country, league);

            return View(matches);
        }

        public IActionResult Picks(int matchId)
        {
            var match = _fixtures.GetMatchById(matchId);

            return View(match);
        }

        [HttpGet]
        public IActionResult Predict(int matchId, string selection)
        {

            PostViewModel model = new PostViewModel
            {
                AppUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                MatchId = matchId,
                Tip = selection,
                Fixture = _fixtures.GetMatchById(matchId)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Predict(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post
                {
                    AppUserId = model.AppUserId,
                    Tip = model.Tip,
                    Thoughts = model.Thoughts,
                    MatchId = model.MatchId,
                    PostDate = DateTime.Now
                };

                _fixtures.AddPost(post);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
