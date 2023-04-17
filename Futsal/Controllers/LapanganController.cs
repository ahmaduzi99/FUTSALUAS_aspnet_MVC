using Futsal.data;
using Futsal.Models;
using Futsal.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Futsal.Controllers
{
	public class LapanganController : Controller
	{
        private readonly MysqlContext _context;
		private readonly IWebHostEnvironment _env;

		public LapanganController(MysqlContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}
		public IActionResult Index()
		{
            List<lapangan> lapang = _context.lapang.ToList();
            return View(lapang);
        }

        public IActionResult Detail(int id)
        {
            var lapang = _context.lapang.FirstOrDefault(x => x.Id == id);


            return View(lapang);
        }

        public IActionResult Create()
        {
            return View();
        }

      

       [HttpPost]
        public IActionResult Create([FromForm] LapanganForm data, IFormFile photo)
        {

            var fileName = "photo_" + data.NamaLapang + Path.GetExtension(photo.FileName);
            var filepath = Path.Combine(_env.WebRootPath, "upload", fileName);

            using (var stream = System.IO.File.Create(filepath))
            {
                photo.CopyTo(stream);
            }

            var lapangan = new lapangan()
            {
                NamaLapang = data.NamaLapang,
                alamat = data.alamat,
                number = data.number,
                photo = fileName,
            };

            _context.lapang.Add(lapangan);
            _context.SaveChanges();
            return RedirectToAction("Index", "Lapangan");
        }

        public IActionResult Edit(int id)
        {
            var lapangan = _context.lapang.FirstOrDefault(x => x.Id == id);
            return View(lapangan);

        }


        [HttpPost]
        public IActionResult Edit([FromForm] lapangan data)
        {
            _context.lapang.Update(data);
            _context.SaveChanges();
            return RedirectToAction("index","Lapangan");
        }


		public IActionResult Download(int id)
		{
			var lapang = _context.lapang.FirstOrDefault(x => x.Id == id);
			var filePath = Path.Combine(_env.WebRootPath, "upload", lapang.photo);

			return File(System.IO.File.ReadAllBytes(filePath), "image/png", Path.GetFileName(filePath));
		}

		public IActionResult Delete(int id)
		{
			var lapang = _context.lapang.FirstOrDefault(x => x.Id == id);
			_context.lapang.Remove(lapang);
			_context.SaveChanges();
			return RedirectToAction("Index","Lapangan");
		}
	}
}
