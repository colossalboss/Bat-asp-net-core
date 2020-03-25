using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _9jaTips.Entities;
using _9jaTips.Services.Interfaces;
using _9jaTips.Web.ViewModels;
using Humanizer;
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

        [HttpGet]
        public IActionResult Details(Guid id)
        {

            var post = _fixtures.GetPostById(id);
            var match = _fixtures.GetMatchById(post.MatchId);

            if (post != null)
            {
                DetailsViewModel model = new DetailsViewModel
                {
                    AppUserId = post.AppUserId,
                    Comments = post.Comments,
                    Id = post.Id,
                    TimeStamp = post.PostDate.Humanize(),
                    Thoughts = post.Thoughts,
                    Prediction = $"{match.Home} vs {match.Away} #{post.Tip}",
                    Location = $"{match.League} in {match.Country}"
                };

                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Details(DetailsViewModel model)
        {
            // Check if postID exist
            if (model.Id != null)
            {
                Comment comment = new Comment
                {
                    AppUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    Message = model.Message,
                    PostId = model.Id,
                    TimeStamp = DateTime.Now
                };

                var saved = _fixtures.AddComment(comment);

                if (saved != null)
                {
                    return RedirectToAction("Details", new { id = model.Id });
                }

                return View(model);
            }

            return RedirectToAction("Index");
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

        [HttpPost]
        public IActionResult Like(Guid postId)
        {
            var check = _fixtures.HasLiked(postId, Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            if (check == false)
            {
                Like like = new Like
                {
                    PostId = postId,
                    UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
                };
                _fixtures.AddLike(like);
                return RedirectToAction("Details", new { id = postId });
            }
            return RedirectToAction("Details", new { id = postId });
        }

        // AJAX
        public async Task<IActionResult> GetOne(Guid id)
        {
            var post = _fixtures.GetOnePost(id);
            var user = await userManager.FindByIdAsync(post.AppUserId.ToString());
            if (post != null)
            {
                var postInfo = new AjaxPostViewModel
                {
                    Id = post.Id,
                    Location = $"{_fixtures.GetMatchById(post.MatchId).League} in {_fixtures.GetMatchById(post.MatchId).Country}",
                    Thoughts = post.Thoughts,
                    TimeStamp = post.PostDate.Humanize(),
                    Tip = $"{_fixtures.GetMatchById(post.MatchId).Home} vs {_fixtures.GetMatchById(post.MatchId).Away} #{post.Tip}",
                    UserId = post.AppUserId,
                    UserName = user.UserName.Split("@")[0],
                };
                return Json(new { success = true, data = postInfo });
            }
            else
            {
                return Json(new { success = false, message = "Invalid Post" });
            }
        }

        [HttpPost]
        public IActionResult PostComment(Comment model)
        {
            if (model.AppUserId != null)
            {
                Comment comment = new Comment
                {
                    AppUserId = model.AppUserId,
                    Message = model.Message,
                    PostId = model.PostId,
                    TimeStamp = DateTime.Now

                };
                var saved = _fixtures.AddComment(comment);

                if (saved != null)
                {
                    return Json(new { success = true, data = saved });
                }
            }
            return Json(new { success = false, message = "Invalid Comment" });
        }
    }
}
