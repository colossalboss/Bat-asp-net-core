using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _9jaTips.Web.Models;
using _9jaTips.Services.Interfaces;
using _9jaTips.Web.ViewModels;

namespace _9jaTips.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFixtures _fixtures;

        public HomeController(ILogger<HomeController> logger, IFixtures fixtures)
        {
            _logger = logger;
            _fixtures = fixtures;
        }

        public IActionResult Index()
        {
            var posts = _fixtures.GetAllPosts();

            var modelList = new List<ListPostViewModel>();

            foreach (var post in posts)
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
