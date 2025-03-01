using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0112.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Mission08_Team0112.Controllers;

public class HomeController : Controller
{
    private _7HabitsDatabaseContext _context;

    public HomeController(_7HabitsDatabaseContext temp)
    {
        _context = temp;
    }
    
    public IActionResult Quadrant()
    {
        //filter and only pass the ones which are completed
        var tasks = _context.ToDos
            .Include(x => x.Category)
            .Where(x => x.Completed == false).ToList();
        return View(tasks);
        
    }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDo response)
        {
            _context.Add(response);
            _context.SaveChanges();

            return RedirectToAction("Quadrant"); 
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.ToDos
                .Single(x => x.TaskId == id);
            
            ViewBag.Categories = _context.Categories
                .OrderBy(x=>x.CategoryName).ToList();
            return View(recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(ToDo updatedInfo)
        {
            var existingTask = _context.ToDos.SingleOrDefault(x => x.TaskId == updatedInfo.TaskId);

            if (existingTask != null)
            {
                existingTask.TaskName = updatedInfo.TaskName;
                existingTask.DueDate = updatedInfo.DueDate;
                existingTask.Quadrant = updatedInfo.Quadrant;
                existingTask.CategoryId = updatedInfo.CategoryId;
                existingTask.Completed = updatedInfo.Completed;

                _context.SaveChanges(); // Save only changes, not create a new record
            }

            return RedirectToAction("Quadrant");
        }

        
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.ToDos
                .Single(x => x.TaskId == id); //using single to only have 1 record
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(ToDo recordToDelete)
        {
            _context.ToDos.Remove(recordToDelete);
            _context.SaveChanges();
            return RedirectToAction("Quadrant");
        }
    
    
}
