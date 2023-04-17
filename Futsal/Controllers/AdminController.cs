using Futsal.data;
using Futsal.Models;
using Futsal.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Futsal.Controllers
{
	public class AdminController : Controller
	{
        private readonly MysqlContext _context;
        private readonly IWebHostEnvironment _env;

        public AdminController(MysqlContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
		{
			List<Admin> admins = _context.admins.ToList();
			return View(admins);
			
		}

        public IActionResult Detail(int id)
        {
            var admin = _context.admins.FirstOrDefault(x => x.Id == id);


            return View(admin);
        }

        public IActionResult Create()
		{
			return View();
		}

        [HttpPost]
        public IActionResult Create([FromForm] AdminForm data, IFormFile foto)
        {

            if (!ModelState.IsValid)
             {
                 return View();
             }

            var fileName = "photo_" + data.username + Path.GetExtension(foto.FileName);
            var filepath = Path.Combine(_env.WebRootPath, "upload", fileName);

            using (var stream = System.IO.File.Create(filepath))
            {
                foto.CopyTo(stream);
            }

            var admins = new Admin()
            {
                username = data.username,
                email = data.email,
                phone = data.phone,
                alamat = data.alamat,
                password=data.password,
                foto = fileName,
            };

            _context.admins.Add(admins);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Edit(int id)
        {
            var admin = _context.admins.FirstOrDefault(x => x.Id == id);
            return View(admin);

        }


        [HttpPost]
        public IActionResult Edit([FromForm] Admin data)
        {
            _context.admins.Update(data);
            _context.SaveChanges();
            return RedirectToAction("index", "Admin");
        }


        public IActionResult Download(int id)
        {
            var admin = _context.admins.FirstOrDefault(x => x.Id == id);
            var filePath = Path.Combine(_env.WebRootPath, "upload", admin.foto);

            return File(System.IO.File.ReadAllBytes(filePath), "image/png", Path.GetFileName(filePath));
        }

        public IActionResult Delete(int id)
        {
            var admin = _context.admins.FirstOrDefault(x => x.Id == id);
            _context.admins.Remove(admin);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult LapanganView()
        {
            List<lapangan> lapang = _context.lapang.ToList();
            return View(lapang);
        }

    }
}
