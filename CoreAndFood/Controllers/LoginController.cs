using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using CoreAndFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;
        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }
        public async Task<IActionResult> GirisYap(Admin p)
        {
            var bilgiler = _context.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.UserName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("GirisYap");

        }
    }
}
