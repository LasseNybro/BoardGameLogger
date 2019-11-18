using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BoardGameLogger.Models;
using BoardGameLogger.Services;

namespace BoardGameLogger.Controllers
{
    public class HomeController : Controller
    {
        private IBoardGameData _boardGameData;

        public HomeController(IBoardGameData boardGameData)
        {
            _boardGameData = boardGameData;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _boardGameData.GetAll();
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
        //A Search function for board games on the main page
        [HttpPost]
        public IActionResult Index(GenreType genre, string name)
        {
            var model = _boardGameData.GetAllGenreName(genre, name);
            return View("Index", model);
        }
    }
}
