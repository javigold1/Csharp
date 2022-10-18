using WeddingPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class WeddingsController : Controller
{
    private WeddingPlannerContext db;
    public WeddingsController(WeddingPlannerContext context)
    {
        db = context;
    }

    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }

    [HttpGet("/weddings/welcome")]
    public IActionResult Welcome()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }

        List<Wedding> allWeddings = db.Weddings
        .Include(p => p.Planner)
        .Include(r => r.RsvpAssociation)
        .ToList();

        return View("Welcome", allWeddings);

    }

    [HttpGet("/weddings/new")]
    public IActionResult New()
    {
        return View("New");
    }

    [HttpPost("/weddings/create")]
    public IActionResult Create(Wedding newWedding)
    {
        if (!ModelState.IsValid)
        {
            return New();
        }
        newWedding.UserId = (int)uid;
        db.Weddings.Add(newWedding);
        db.SaveChanges();
        //return RedirectToRoute(new { controller = "Home", action = "Index" });
        return RedirectToAction("Welcome");
    }

    [HttpPost("/weddings/{weddingId}/delete")]
    public IActionResult deletewedding(int weddingId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        Wedding? wedding = db.Weddings.FirstOrDefault(p => p.WeddingId == weddingId);

        if (wedding != null && wedding.UserId == uid)
        {
            db.Weddings.Remove(wedding);
            db.SaveChanges();
        }
        return RedirectToAction("welcome");

    }
    [HttpPost("/weddings/{weddingId}/rsvp")]
    public IActionResult rsvpwedding(int weddingId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }

        Association? existingrsvp = db.Associations.FirstOrDefault(r => r.WeddingId == weddingId && r.UserId == (int)uid);

        if (existingrsvp == null)
        {
            Association newRsvp = new Association()
            {
                UserId = (int)uid,
                WeddingId = weddingId
            };
            db.Associations.Add(newRsvp);
        }
        else
        {
            db.Associations.Remove(existingrsvp);
        }

        db.SaveChanges();
        return RedirectToAction("welcome");

    }

    [HttpGet("/weddings/{weddingId}")]
    public IActionResult Detail(int weddingId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        Wedding? wedding = db.Weddings
            .Include(r => r.RsvpAssociation)
            .ThenInclude(assoc => assoc.user)
            .FirstOrDefault(w => w.WeddingId == weddingId);

        return View("detail", wedding);

    }

}