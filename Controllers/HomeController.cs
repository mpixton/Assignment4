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
            List<Recommendation> Top5 = new List<Recommendation>();

            Top5[0] = new Recommendation(
                rank: 1,
                name: "Cafe Rio",
                address: "2244 University Pkwy, Provo, UT 84604",
                phone: "(801) 375-5133)",
                dish: "Sweet Pork Burrito"
                );

            Top5[1] = new Recommendation(
                rank: 2,
                name: "Bombay House",
                address: "463 N University Ave, Provo, UT 84604",
                link: "bombayhouse.com"
                );

            Top5[2] = new Recommendation(
                rank: 3, 
                name: "Costco Food Court",
                address: "648 E 800 S, Orem, UT 84097",
                dish: "Pizza Slice"
                );

            Top5[3] = new Recommendation(
                rank: 4,
                name: "MOA Cafe",
                address: "500 Campus Dr, Provo, UT 84602",
                link: "dining.byu.edu",
                phone: "(801) 422-6990"
                );

            Top5[4] = new Recommendation(
                rank: 5,
                name: "The Skyroom Restaurant",
                address: "Ernest L Wilkinson Student Center, 6th Floor, Provo, UT 84602",
                phone: "(801) 422-9020"
                );

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
        public IActionResult AddRecomendation(Recommendation rec)
        {
            if (ModelState.IsValid)
            {
                RecommendationStorage.AddRecommendation(rec);
                ViewData["Added"] = true;
                return View("UserRecommendations");
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
            return View(RecommendationStorage.Recommendations);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
