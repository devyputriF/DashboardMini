using Dashboardmini.Data;
using Dashboardmini.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Dashboardmini.Services;
using Dashboardmini.Models;

namespace Dashboardmini.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var UserAccount = _context.Users.FirstOrDefault(e => e.UserName == model.Username);

                if (UserAccount == null)
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    return RedirectToAction("Login");
                }

                if(!Services.VerifyAccount.VerifyPassword(model.Password, UserAccount.PasswordHash))
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    return RedirectToAction("Login");
                }


                HttpContext.Session.SetString("Username", UserAccount.UserName);
                HttpContext.Session.SetString("Password", UserAccount.PasswordHash);
                HttpContext.Session.SetInt32("Role", (int)UserAccount.UserRole);

                ViewBag.Title = "Login";
                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Login");

        }
    }
}
