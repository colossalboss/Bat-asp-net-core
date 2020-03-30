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

        [HttpGet]
        public async Task<IActionResult> FilterPost(string country)
        {
            var posts = _fixtures.GetCountryPosts(country);

            ViewBag.Country = country;

            var modelList = new List<ListPostViewModel>();

            foreach (var post in posts)
            {
                var user = await userManager.FindByIdAsync(post.AppUserId.ToString());
                var streak = _fixtures.GetUserStreak(post.AppUserId);
                var model = new ListPostViewModel
                {
                    Fixture = _fixtures.GetMatchById(post.MatchId),
                    Id = post.Id,
                    Thoughts = post.Thoughts,
                    Tip = post.Tip,
                    UserId = post.AppUserId,
                    PostDate = post.PostDate.Humanize(),
                    Comments = post.Comments,
                    Image = user.Image,
                    Streak = streak
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {

            var post = _fixtures.GetPostById(id);
            var match = _fixtures.GetMatchById(post.MatchId);
            var user = await userManager.FindByIdAsync(post.AppUserId.ToString());

            var postComments = new List<CommentsViewModel>();

            foreach(var comment in post.Comments)
            {
                var streak = _fixtures.GetUserStreak(comment.AppUserId);
                var pc = new CommentsViewModel
                {
                    AppUserId = comment.AppUserId,
                    Id = comment.Id,
                    Message = comment.Message,
                    PostId = comment.PostId,
                    Time = comment.TimeStamp.Humanize(),
                    Streak = streak
                };
                postComments.Add(pc);
            }

            if (post != null)
            {
                DetailsViewModel model = new DetailsViewModel
                {
                    AppUserId = post.AppUserId,
                    PostComments = postComments,
                    Id = post.Id,
                    TimeStamp = post.PostDate.Humanize(),
                    Thoughts = post.Thoughts,
                    Prediction = $"{match.Home} vs {match.Away} #{post.Tip}",
                    Location = $"{match.League} in {match.Country}",
                    UserImage = user.Image
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
                    PostDate = DateTime.Now,
                    Outcome = "Pending"
                };

                _fixtures.AddPost(post);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        //[HttpPost]
        //public IActionResult Like(Guid postId)
        //{
        //    var check = _fixtures.HasLiked(postId, Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        //    if (check == false)
        //    {
        //        Like like = new Like
        //        {
        //            PostId = postId,
        //            UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
        //        };
        //        _fixtures.AddLike(like);
        //        string referer = Request.Headers["Referer"].ToString();
        //        return Redirect(referer);
        //    }
        //    string referrer = Request.Headers["Referer"].ToString();
        //    return Redirect(referrer);
        //}

        [HttpPost]
        public IActionResult Like(Like model)
        {
            if (model != null)
            {
                var check = _fixtures.HasLiked(model.PostId, Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if (check == null)
                {
                    Like like = new Like
                    {
                        PostId = model.PostId,
                        UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
                    };
                    var result = _fixtures.AddLike(like);
                    if (result != null)
                    {
                        return Json(new { data = result, added = true });
                    }
                }
                else
                {
                    var unliked = _fixtures.Unlike(model.PostId, Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                    if (unliked != null)
                    {
                        return Json(new { data = unliked, removed = true });
                    }
                }
            }

            return Json(new { message = "An Error Occurred" });

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
                    UserImage = user.Image
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
                    AppUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
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
