using Microsoft.AspNetCore.Mvc;
using Mission08_Team0309.Models;
using Mission08_Team0309.Models.ViewModels;

namespace Mission08_Team0309.Controllers
{
    public class TasksController : Controller
    {
        private ITaskRepository _repo;

        public TasksController(ITaskRepository repo)
        {
            _repo = repo;
        }

        // GET: /Tasks/Create
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new TaskFormViewModel
            {
                Task = new UserTask(),
                Categories = _repo.Categories.ToList()
            };

            return View(vm);
        }

        // POST: /Tasks/Create
        [HttpPost]
        public IActionResult Create(TaskFormViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(vm.Task);
                return RedirectToAction("Index", "Home"); // temporary redirect 
            }

            // if validation fails, reload categories and show the form again
            vm.Categories = _repo.Categories.ToList();
            return View(vm);
        }

        // GET: /Tasks/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);

            if (task == null)
            {
                return NotFound();
            }

            var vm = new TaskFormViewModel
            {
                Task = task,
                Categories = _repo.Categories.ToList()
            };

            return View(vm);
        }

        // POST: /Tasks/Edit
        [HttpPost]
        public IActionResult Edit(TaskFormViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(vm.Task);
                return RedirectToAction("Index", "Home"); // temporary redirect 
            }

            vm.Categories = _repo.Categories.ToList();
            return View(vm);
        }

        // Placeholder so the navbar link doesn't 404 (for now, it will redirect to the Database connectivity test table when Index or Home are clicked)
        public IActionResult Quadrants()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}