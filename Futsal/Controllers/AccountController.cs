using Futsal.data;
using Futsal.Models;
using Futsal.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Futsal.Controllers
{
    public class AccountController : Controller
    {

        private readonly MysqlContext _mysqlContext;

        public AccountController(MysqlContext mysqlContext)
        {
            _mysqlContext = mysqlContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] Login data)
        {
            var user = _mysqlContext.User.Where(x => x.username == data.Username && x.password == data.Password).FirstOrDefault();
            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim("username", user.username),
                    new Claim("role","Admin")
                };

                var identity = new ClaimsIdentity(claims, "Cookie", "name", "role");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return Redirect("/dashboard/index");
            }

            return View();
        }
    }
}
