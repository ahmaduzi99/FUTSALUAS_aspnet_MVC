using Futsal.data;
using Futsal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Futsal.Controllers
{
	public class JadwalController : Controller
	{
		private readonly MysqlContext _context;
		private readonly IWebHostEnvironment _env;

		public JadwalController(MysqlContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}
		public IActionResult Index()
		{
			var books = _context.Book.Include(b => b.Lapangan).Include(b => b.Status).ToList();
			return View(books);
		}
	}
}
