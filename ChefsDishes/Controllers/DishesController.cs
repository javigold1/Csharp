using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;
namespace ChefsDishes.Controllers;

public class DishesController : Controller
{
    private ChefsDishesContext db;
    public DishesController(ChefsDishesContext context)
    {
        db = context;
    }

    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        ViewBag.AllChefs = db.Chefs.ToList();
        return View("New");
    }
    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("NO");
            return New();
        }
        db.Dishes.Add(newDish);
        db.SaveChanges();
        //return RedirectToRoute(new { controller = "Home", action = "Index" });
        return RedirectToAction("All");
    }

    [HttpGet("/dishes/all")]
    public IActionResult All()
    {
        List<Dish> allDishes = db.Dishes
        .Include(d => d.Author)
        .ToList();
        return View("All", allDishes);
    }

    [HttpGet("/dishes/{DishID}")]
    public IActionResult Detail(int dishID)
    {
        Dish? dish = db.Dishes.FirstOrDefault(p => p.DishId == dishID);

        // In case user manually types in an invalid ID in the url
        if (dish == null)
        {
            return RedirectToAction("All");
        }

        return View("Detail", dish);
    }
}