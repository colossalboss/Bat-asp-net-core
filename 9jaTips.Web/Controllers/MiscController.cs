using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9jaTips.Services.Interfaces;
using _9jaTips.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _9jaTips.Web.Controllers
{
    public class MiscController : Controller
    {
        private readonly IFixtures _fixtures;

        public MiscController(IFixtures fixtures)
        {
            _fixtures = fixtures;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TrendingLeagues()
        {
            return View();
        }

        public IActionResult Table()
        {
            return View();
        }
    }
}
