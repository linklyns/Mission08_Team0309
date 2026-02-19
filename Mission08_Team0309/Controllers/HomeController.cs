using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var tasks = _repo.Tasks.ToList();
            return View(tasks);
        }

        // GET: Display all tasks in quadrant layout
        public IActionResult Quadrants()
        {
            var tasks = _repo.Tasks.Where(t => !t.Completed).ToList();
            return View(tasks);
        }

        // GET: Show the Add Task form
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = new SelectList(_repo.Categories.ToList(), "CategoryId", "CategoryName");
            return View();
        }

        // POST: Save a new task
        [HttpPost]
        public IActionResult AddTask(UserTask task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
                return RedirectToAction("Quadrants");
            }
            ViewBag.Categories = new SelectList(_repo.Categories.ToList(), "CategoryId", "CategoryName");
            return View(task);
        }

        // GET: Show the Edit Task form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(_repo.Categories.ToList(), "CategoryId", "CategoryName", task.CategoryId);
            return View(task);
        }

        // POST: Save edited task
        [HttpPost]
        public IActionResult Edit(UserTask task)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(task);
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
