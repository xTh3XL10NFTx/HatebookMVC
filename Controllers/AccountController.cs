using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WebApplication2.Data;
using WebApplication2.Models.Account;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register obj)
        {
            if (obj.Password != obj.PassRepeat)
            {
                ModelState.AddModelError("PassRepeat", "The password must be the same!");

            }

            foreach (var checkreg in _db.Registers)
            {
                if (obj.Email == checkreg.Email)
                {
                    ModelState.AddModelError("Email", "E-mail already exists!");
                }
            }

            if (ModelState.IsValid)
            {
                _db.Registers.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "User created successfully";
                return RedirectToAction("Login");
            }
            return View(obj);
        }

        public int identity;

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login obj)
        {
            foreach (var checkreg in _db.Registers)
            {
                if (obj.Email == checkreg.Email && obj.Password == checkreg.Password)
                {
                    if (ModelState.IsValid)
                    {
                        identity = checkreg.Id;
                        TempData["success"] = "User logged in successfully";
                        return RedirectToAction("AdminPanel");
                    }
                }
            }
            ModelState.AddModelError("CustomError", "E-mail or password not found!");
            return View();
        }

        public IActionResult AdminPanel()
        {
            foreach(var stat in _db.Registers)
            {
                if(stat.Id == identity)
                {
                    ViewBag.FirstN = stat.Fname;
                    ViewBag.LastN = stat.Lname;
                }
            }
            return View();
        }

    }
}
