using WeddingPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UsersController : Controller
{
    private WeddingPlannerContext db;
    public UsersController(WeddingPlannerContext context)
    {
        db = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (db.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "is taken");
            }
        }

        // in case any above custom errors were added
        if (ModelState.IsValid == false)
        {
            // return index function so that error messages will be displayed
            return Index();
        }

        //hash pw
        PasswordHasher<User> hashBrowns = new PasswordHasher<User>();
        newUser.Password = hashBrowns.HashPassword(newUser, newUser.Password);

        db.Users.Add(newUser);
        db.SaveChanges();

        HttpContext.Session.SetInt32("UUID", newUser.UserId);
        HttpContext.Session.SetString("Email", newUser.Email);
        HttpContext.Session.SetString("FName", newUser.FirstName);
        return RedirectToAction("welcome", "weddings");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            //display error messages
            return Index();
        }

        User? dbUser = db.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);

        if (dbUser == null)
        {
            // Normally these kinds of errors should be vague to avoid phishing.
            // but we will keep them specific to help us test.
            // generic message example: "Username/Password don't match"
            ModelState.AddModelError("LoginEmail", "not found");
            return Index();
        }

        // if we get to this point, user exists, so we need to check password matching
        PasswordHasher<LoginUser> hashBrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompareResult = hashBrowns.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        // if PasswordVerificationResult == 0, passwords don't match
        if (pwCompareResult == 0)
        {
            // Normally these kinds of errors should be vague to avoid phishing.
            // but we will keep them specific to help us test.
            ModelState.AddModelError("LoginPassword", "invalid password");
            return Index();
        }

        // no returns happened, therefore no errors
        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        HttpContext.Session.SetString("Email", dbUser.Email);
        HttpContext.Session.SetString("FName", dbUser.FirstName);
        return RedirectToAction("Welcome", "Weddings");
    }

    [HttpPost("/logout")]
    public IActionResult Logout(LoginUser loginUser)
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

}