using Futsal.data;
using Futsal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
            var bookings = _context.Book.Include(b => b.Lapangan).Include(b => b.Status).ToList();
            return View(bookings);

        }

        public IActionResult Create(int id)
        {
            var getIdLapangan = _context.lapang.Where(l => l.Id == id).FirstOrDefault();
            return View(getIdLapangan);
           
        }

        [HttpPost]
        public IActionResult Create([FromForm] booking data, int idLapangan)
        {

            var cekLapangan = _context.lapang.Where(l => l.Id == idLapangan).FirstOrDefault();
            var cekData = _context.Book.Where(b => b.start == data.start && b.Lapangan.NamaLapang == cekLapangan.NamaLapang).FirstOrDefault();
            var hasil = _context.Statuses.Where(s => s.Id == 1).FirstOrDefault();

            if (cekData != null)
            {
                hasil = _context.Statuses.Where(s => s.Id == 2).FirstOrDefault();
            }

            var newBooking = new booking
            {
                nama = data.nama,
                Lapangan = cekLapangan,
                date = data.date,
                end = data.end,
                start = data.start,
                email = data.email,
                nphp = data.nphp,
                Status = hasil
            };
            _context.Book.Add(newBooking);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Lapangan = _context.lapang.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.NamaLapang
            });

            ViewBag.Status = _context.Statuses.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Stat
            });

            var bookingId = _context.Book.Include(b => b.Lapangan).Include(b => b.Status).Where(b => b.Id == id).FirstOrDefault();
            return View(bookingId);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] booking book, int lapanganId, int statusId)
        {
            book.Lapangan = _context.lapang.Where(l => l.Id == lapanganId).FirstOrDefault();
            book.Status = _context.Statuses.Where(l => l.Id == statusId).FirstOrDefault();
            _context.Book.Update(book);
            _context.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index", "booking");
        }

        public IActionResult Delete(int id)
        {
            var booking = _context.Book.FirstOrDefault(x => x.Id == id);
            _context.Book.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction("Index", "booking");
        }
    }
}