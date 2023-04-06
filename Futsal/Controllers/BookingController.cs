using Futsal.data;
using Futsal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Futsal.Controllers
{
	    

    public class BookingController : Controller
    {
		private readonly MysqlContext _context;

		public BookingController(MysqlContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
            /*List<booking> bookings = _context.Book.ToList();
            return View(bookings);*/
			return View();
        }


        public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create([FromForm] booking data)
		{
			_context.Book.Add(data);
			_context.SaveChanges();
			return RedirectToAction("Index","Home");
		}
	}
}
