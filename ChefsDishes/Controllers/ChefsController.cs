using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;
namespace ChefsDishes.Controllers;

public class ChefsController : Controller
{
    private ChefsDishesContext db;
    public ChefsController(ChefsDishesContext context)
    {
        db = context;
    }

    [HttpGet("chefs/new")]
    public IActionResult New()
    {
        return View("New");
    }
    [HttpPost("chefs/create")]
    public IActionResult Create(Chef newChef)
    {
        if (!ModelState.IsValid)
        {
            return New();
        }
        db.Chefs.Add(newChef);
        db.SaveChanges();
        //return RedirectToRoute(new { controller = "Home", action = "Index" });
        return RedirectToAction("All");
    }
    [HttpGet("All")]
    public IActionResult All()
    {
        List<Chef> allChefs = db.Chefs
        .Include(chef => chef.ChefDishes)
        .ToList();
        return View("All", allChefs);
    }

    [HttpGet("/chefs/{ChefID}")]
    public IActionResult Detail(int chefID)
    {
        Chef? chef = db.Chefs.FirstOrDefault(p => p.ChefId == chefID);

        // In case user manually types in an invalid ID in the url
        if (chef == null)
        {
            return RedirectToAction("All");
        }

        return View("Detail", chef);
    }


}