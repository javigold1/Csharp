using Microsoft.AspNetCore.Mvc;

public class FormController : Controller
{
    // specifiying the type of request and the route
    [HttpGet("")]
    // ViewResult is the type of return
    public ViewResult Index()
    {
        // View is a function in the MVC library
        return View("Index");
    }

    // specifiying the type of request and the route
    [HttpPost("results")]
    // ViewResult is the type of return
    public IActionResult Display(string Name, string Location, string Language, string Comment)
    {
        ViewBag.Name = Name;
        ViewBag.Location = Location;
        ViewBag.Language = Language;
        ViewBag.Comment = Comment;
        // View is a function in the MVC library
        return View("Display");
    }
}