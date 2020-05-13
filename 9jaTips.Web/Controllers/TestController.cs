using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9jaTips.Entities;
using _9jaTips.Services.Interfaces;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _9jaTips.Web.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IFixtures _fixtures;
        private readonly UserManager<AppUser> userManager;

        public TestController(IFixtures fixtures, UserManager<AppUser> userManager)
        {
            _fixtures = fixtures;
            this.userManager = userManager;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var postItems = _fixtures.GetPostItems();
            foreach(var post in postItems)
            {
                var user = await userManager.FindByIdAsync(post.UserId.ToString());
                post.Username = user.UserName.Split("@")[0];
            }
            return Ok(postItems);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var postItem = _fixtures.GetPostItemById(id);
            if (postItem == null)
            {
                return NotFound();
            }

            var user = await userManager.FindByIdAsync(postItem.UserId.ToString());
            
            postItem.Username = user.UserName.Split("@")[0];

            return Ok(postItem);
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
