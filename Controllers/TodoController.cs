using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication_f.Mappers;
using WebApplication_f.Models;
using WebApplication_f.Services;
using WebApplication_f.ViewModels;

namespace WebApplication_f.Controllers
{
    public class TodoController : Controller
    {
        ISessionManagerService session; //Injection de DEP
        public TodoController(ISessionManagerService session)
        {
            this.session = session;
        }

        public IActionResult Index()
        {
            List<Todo> list = session.Get<List<Todo>>("todos", HttpContext);
            ViewBag.count = list.Count;
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(TodoAddVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            List<Todo> list;
            if (HttpContext.Session.GetString("todos") == null)
            {
                list = new List<Todo>();
            }
            else
            {
                list = session.Get<List<Todo>>("todos", HttpContext);
            }

            Todo todo = TodoMapper.GetTodoFromTodoAddVM(vm);

            list.Add(todo);

            session.Add("todos", list, HttpContext);

            return RedirectToAction(nameof(Index));
        }
    }
}
