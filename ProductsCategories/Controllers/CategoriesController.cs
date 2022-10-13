using Microsoft.AspNetCore.Mvc;
using ProductsCategories.Models;
using Microsoft.EntityFrameworkCore;
namespace ProductsCategories.Controllers;

public class CategoriesController : Controller
{
    private ProductsCategoriesContext db;
    public CategoriesController(ProductsCategoriesContext context)
    {
        db = context;
    }
    [HttpGet("/categories/new")]
    public IActionResult New()
    {
        return View("All");
    }
    [HttpPost("/categories/create")]
    public IActionResult Create(Category newCategory)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("NO");
            return New();
        }
        db.Categories.Add(newCategory);
        db.SaveChanges();
        //return RedirectToRoute(new { controller = "Home", action = "Index" });
        return RedirectToAction("All");
    }

    [HttpGet("categories/all")]
    public IActionResult All()
    {
        List<Category> allCategories = db.Categories
        .ToList();
        return View("All", allCategories);
    }

    [HttpGet("/categories/{CategoryId}")]
    public IActionResult Detail(int categoryId)
    {
        Category? category = db.Categories
            .Include(cat => cat.CatagoryAss)
            .ThenInclude(assoc => assoc.product)
            .FirstOrDefault(cat => cat.CategoryId == categoryId);

        List<Product>? UnassociatedProducts = db.Products
            .Include(p => p.ProductCategories)
            .Where(p => p.ProductCategories.All(a => a.CategoryId != categoryId))
            .ToList();

        ViewBag.UnassociatedProducts = UnassociatedProducts;
        return View("detail", category);

    }

    [HttpPost("categories/addproduct")]
    public IActionResult AddProduct(int Id, int catId)
    {
        // Category? retrievedCategory = db.Categories.FirstOrDefault(c => c.CategoryId == Id);
        // Product? currentProduct = db.Products.FirstOrDefault(p => p.ProductId == HttpContext.Session.GetInt32("ProductId"));
        Association newAssociation = new Association();
        newAssociation.ProductId = Id;
        newAssociation.CategoryId = catId;
        // newAssociation.Category = retrievedCategory;
        // newAssociation.Product = currentProduct;
        db.Associations.Add(newAssociation);
        db.SaveChanges();
        return RedirectToAction("Detail", new { categoryID = catId });
    }
}