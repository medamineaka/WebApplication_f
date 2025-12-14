using Microsoft.AspNetCore.Mvc;
using WebApplication_f.ViewModels;

namespace WebApplication_f.Controllers
{
    public class UserController : Controller
    {
        public IActionResult LoginForm()
        {
            return View();
        }

        public IActionResult Login(User u)
        {
            if (ModelState.IsValid)
            {
                //Logique de verfication
            }
            return View("LoginForm");
        }
    }
}
