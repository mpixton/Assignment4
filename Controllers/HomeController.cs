using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurants.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: /
        [HttpGet]
        public IActionResult Index()
        {
            List<string> Top5 = new List<string>();

            foreach(Top5Recommendation rec in Top5Recommendation.GetTop5())
            {
                Top5.Add($"#{rec.Rank}- {rec.Name} {rec.Address} {rec.PhoneNumber} {rec.FavDish ?? "It's all good!"} {rec.WebsiteLink}");
            }

            return View(Top5);
        }

        // GET: /AddRecommendation
        [HttpGet("AddRecommendation")]
        public IActionResult AddRecommendation()
        {
            return View();
        }

        // POST: /AddRecomendation
        [HttpPost("AddRecommendation")]
        public IActionResult AddRecommendation(UserRecommendation rec)
        {
            if (ModelState.IsValid)
            {
                RecommendationStorage.AddRecommendation(rec);
                ViewData["Added"] = true;
                return View("UserRecommendations", RecommendationStorage.Recommendations);
            }
            else
            {
                return View(rec);
            }
        }
   
        // GET: /AllRecommendations
        [HttpGet("AllRecommendations")]
        public IActionResult UserRecommendations()
        {
            ViewData["Added"] = false;
            return View("UserRecommendations", RecommendationStorage.Recommendations);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
