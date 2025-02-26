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
        return View();
    }
}