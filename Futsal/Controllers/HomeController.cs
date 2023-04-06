using Futsal.data;
using Futsal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Futsal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MysqlContext _context;

        public HomeController(ILogger<HomeController> logger, MysqlContext c)
        {
            _logger = logger;
            _context = c;
        }

        public IActionResult Index()
        {
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