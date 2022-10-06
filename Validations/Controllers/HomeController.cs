using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Validations.Models;

namespace Validations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("Username", newUser.Username);
            return Redirect("/storytime");
        }

        return View("Index");
    }

    [HttpGet("/storytime")]
    public IActionResult StoryTime()
    {
        if (HttpContext.Session.GetString("Username") == null)
        {
            return Redirect("/");
        }

        string? story = HttpContext.Session.GetString("story");

        if (story == null)
        {
            // No story in session yet, set it to empty string
            // so that it's ready to concat to
            HttpContext.Session.SetString("story", "");
        }

        return View("StoryTime");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
