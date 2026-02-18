using Microsoft.AspNetCore.Mvc;
using Mission08_Team0309.Models;
using System.Diagnostics;

namespace Mission08_Team0309.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var tasks = _repo.Tasks.ToList(); // This is just to make sure the tasks are loaded before we try to display them in the view
            return View(tasks);
        }
    }
}
