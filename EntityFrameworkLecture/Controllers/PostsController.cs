using Microsoft.AspNetCore.Mvc;
using EntityFrameworkLecture.Models;

public class PostsController : Controller
{
    private ForumContext db;
    public PostsController(ForumContext context)
    {
        db = context;
    }

    [HttpGet("/posts/new")]
    public IActionResult New()
    {
        return View("New");
    }
    [HttpPost("/posts/create")]
    public IActionResult Create(Post newPost)
    {
        if (!ModelState.IsValid)
        {
            return New();
        }

        db.Posts.Add(newPost);
        db.SaveChanges();
        return RedirectToAction("All");
    }
    [HttpGet("posts/all")]
    public IActionResult All()
    {
        List<Post> allPosts = db.Posts.ToList();
        return View("All", allPosts);
    }

}