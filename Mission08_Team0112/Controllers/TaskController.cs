using Microsoft.AspNetCore.Mvc;
using Mission08_Team0112.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Mission08_Team0112.Controllers
{
    public class TasksController : Controller
    {
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
                // Save to database logic here (if connected)
                return RedirectToAction("Index");
            }

            // If validation fails, reload categories
            ViewBag.Categories = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Home" },
                new SelectListItem { Value = "2", Text = "School" },
                new SelectListItem { Value = "3", Text = "Work" },
                new SelectListItem { Value = "4", Text = "Church" }
            };

            return View(model);
        }
    }
}