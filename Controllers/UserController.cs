using Microsoft.AspNetCore.Mvc;
using WebApplication_f.ViewModels;

namespace WebApplication_f.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("isAuth") == null)
            {
                return RedirectToAction("LoginForm", "User");
            }
            return View();
        }
        public IActionResult LoginForm()
        {
            return View();
        }

        public IActionResult Login(User u)
        {
            if (ModelState.IsValid)
            {
                string password = new string(u.Password.Reverse());
                if (u.Login == password)
                {
                    HttpContext.Session.SetString("isAuth", "");
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("LoginForm");
        }
        public IActionResult Logout(User u)
        {
                    HttpContext.Session.Clear();
                    return RedirectToAction("LoginForm");
        }
    }
}
