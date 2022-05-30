using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace DB_Interface.Controllers
{
    public class AuthController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            var list = UserRepository.GetUsers();

            return View(list);
        }

        // GET: /<controller/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /<controller>/Register
        [HttpPost]
        public IActionResult Register(UserView credentials)
        {
            int result = UserRepository.RegisterUser(credentials);

            return RedirectToAction("Login");
        }

        // GET: /<controller>/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /<controller>/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginView loginView)
        {
            if (UserRepository.Login(loginView))
            {
                var user = UserRepository.GetUser(loginView.Username);

                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = false,
                });

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            UserRepository.DeleteUser(id);

            return RedirectToAction("Index");
        }
    }
}
