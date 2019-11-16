using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoardGameLogger.Models;
using BoardGameLogger.Data;

namespace BoardGameLogger.Controllers
{
    public class HomeController : Controller
    {
        private IBoardGameData _boardGameData;

        public HomeController(IBoardGameData boardGameData)
        {
            _boardGameData = boardGameData;
        }
        public IActionResult Index()
        {
            var model = _boardGameData.getAll();
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
    }
}
