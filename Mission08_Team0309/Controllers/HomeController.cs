using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission08_Team0309.Models;

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
            return View();
        }

        // GET: Display all tasks in quadrant layout (Home page)
        public IActionResult Quadrants()
        {
            var tasks = _repo.Tasks.Where(t => !t.Completed).ToList();
            return View(tasks);
        }

        // GET: Show the Add/Edit Task form
        [HttpGet]
        public IActionResult AddTask(int? id)
        {
            ViewBag.Categories = new SelectList(_repo.Categories.ToList(), "CategoryId", "CategoryName");

            if (id.HasValue)
            {
                var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id.Value);
                if (task == null)
                {
                    return NotFound();
                }
                ViewBag.Categories = new SelectList(_repo.Categories.ToList(), "CategoryId", "CategoryName", task.CategoryId);
                return View(task);
            }

            return View(new UserTask());
        }

        // POST: Save a new or edited task
        [HttpPost]
        public IActionResult AddTask(UserTask task)
        {
            if (ModelState.IsValid)
            {
                if (task.TaskId == 0)
                {
                    _repo.AddTask(task);
                }
                else
                {
                    _repo.UpdateTask(task);
                }
                return RedirectToAction("Quadrants");
            }
            ViewBag.Categories = new SelectList(_repo.Categories.ToList(), "CategoryId", "CategoryName", task.CategoryId);
            return View(task);
        }

        // POST: Delete a task
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task != null)
            {
                _repo.DeleteTask(task);
            }
            return RedirectToAction("Quadrants");
        }

        // POST: Mark a task as completed
        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task != null)
            {
                task.Completed = true;
                _repo.UpdateTask(task);
            }
            return RedirectToAction("Quadrants");
        }
    }
}
