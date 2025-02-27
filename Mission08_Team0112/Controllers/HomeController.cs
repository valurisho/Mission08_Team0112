using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0112.Models;

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
        
}