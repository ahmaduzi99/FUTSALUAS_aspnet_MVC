using Futsal.data;
using Futsal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Futsal.Controllers
{
	[Authorize]
	public class DashboardController : Controller
	{
		private readonly MysqlContext _context;

		public DashboardController(MysqlContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
				var bookings = _context.Book.Include(b => b.Lapangan).Include(b => b.Status).ToList();
				return View(bookings);
			
		}


    }
	}

