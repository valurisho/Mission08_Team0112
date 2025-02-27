using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0112.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Mission08_Team0112.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Quadrant()
    {
        //var tasks = _context.Tasks
        //.Include(x => x.Category)
        //.Where(x => x.Completed == false).ToList();
        return View();
        //filter and only pass the ones which are completed
    }

    //[HttpGet]
    //public IActionResult Edit(int id)
    
        // var taskToEdit = _context.Tasks
        //.Single(x=>x.TaskId == id);
        
    
        
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Home" },
                new SelectListItem { Value = "2", Text = "School" },
                new SelectListItem { Value = "3", Text = "Work" },
                new SelectListItem { Value = "4", Text = "Church" }
            };
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save to database (if connected)
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Quadrants()
        {
            var tasks = new List<TaskViewModel>
            {
                new TaskViewModel { TaskName = "Project Work", DueDate = DateTime.Now, Quadrant = 1, CategoryId = 3 },
                new TaskViewModel { TaskName = "Study Session", DueDate = DateTime.Now.AddDays(3), Quadrant = 2, CategoryId = 2 }
            };
            return View(tasks); // Loads Views/Tasks/Quadrants.cshtml
        }
    
}
