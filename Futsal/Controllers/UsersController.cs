using Futsal.data;
using Futsal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Futsal.Controllers
{
    public class UsersController : Controller
    {

        private readonly MysqlContext _context;

        public UsersController(MysqlContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Users data)
        {
            _context.User.Add(data);
            _context.SaveChanges();
            return RedirectToAction("Index", "account");
        }
    }
}
