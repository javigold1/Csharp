using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

public class DishesController : Controller
{
    private CrudeliciousContext db;
    public DishesController(CrudeliciousContext context)
    {
        db = context;
    }

    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        return View("New");
    }
    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (!ModelState.IsValid)
        {
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
        List<Dish> allDishes = db.Dishes.ToList();
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


    [HttpGet("edit/{dishId}")]
    public IActionResult EditDish(int dishID)
    {
        Dish? oneDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishID);

        if (oneDish == null)
        {
            return RedirectToAction("All");
        }
        return View("Update", oneDish);
    }

    [HttpPost("update/{dishId}")]
    public IActionResult Update(int dishId, Dish editedDish)
    {
        if (ModelState.IsValid == false)
        {
            return EditDish(dishId);
        }

        Dish? dbDish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);

        if (dbDish == null)
        {
            return RedirectToAction("All");
        }

        dbDish.Name = editedDish.Name;
        dbDish.Chef = editedDish.Chef;
        dbDish.Tastiness = editedDish.Tastiness;
        dbDish.Calories = editedDish.Calories;
        dbDish.Description = editedDish.Description;
        dbDish.UpdatedAt = DateTime.Now;

        db.Dishes.Update(dbDish);
        db.SaveChanges();
        return RedirectToAction("Detail", new { dishID = dbDish.DishId });
    }

    [HttpPost("delete/{deleteDishID}")]
    public IActionResult DeleteDish(int deleteDishID)
    {
        Dish? dbDish = db.Dishes.FirstOrDefault(d => d.DishId == deleteDishID);

        if (dbDish != null)
        {
            db.Dishes.Remove(dbDish);
            db.SaveChanges();
        }
        return RedirectToAction("All");
    }
}