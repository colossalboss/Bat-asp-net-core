using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9jaTips.Entities;
using _9jaTips.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _9jaTips.Web.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly IFixtures _fixtures;
        private readonly UserManager<AppUser> userManager;

        public CommentController(IFixtures fixtures, UserManager<AppUser> userManager)
        {
            _fixtures = fixtures;
            this.userManager = userManager;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<List<CommentDto>> GetAsync(Guid id)
        {
            var comments = _fixtures.GetPostComments(id);
            foreach(var comment in comments)
            {
                var user = await userManager.FindByIdAsync(comment.UserId.ToString());
                comment.Username = user.UserName.Split("@")[0];
            }
            return comments;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
