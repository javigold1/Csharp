
using Microsoft.AspNetCore.Mvc;
using ProductsCategories.Models;
using Microsoft.EntityFrameworkCore;
namespace ProductsCategories.Controllers;


public class ProductsController : Controller
{
    private ProductsCategoriesContext db;
    public ProductsController(ProductsCategoriesContext context)
    {
        db = context;
    }
    [HttpGet("/products/new")]
    public IActionResult New()
    {
        return View("All");
    }
    [HttpPost("/products/create")]
    public IActionResult Create(Product newProduct)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("NO");
            return New();
        }
        db.Products.Add(newProduct);
        db.SaveChanges();
        //return RedirectToRoute(new { controller = "Home", action = "Index" });
        return RedirectToAction("All");
    }
    [HttpGet("products/all")]
    public IActionResult All()
    {
        List<Product> allProducts = db.Products
        .ToList();
        return View("All", allProducts);
    }

    [HttpGet("/products/{ProductId}")]
    public IActionResult Detail(int productId)
    {
        Product? product = db.Products
            .Include(prod => prod.ProductCategories)
            .ThenInclude(assoc => assoc.category)
            .FirstOrDefault(prod => prod.ProductId == productId);

        List<Category>? UnassociatedCategories = db.Categories
            .Include(c => c.CatagoryAss)
            .Where(c => c.CatagoryAss.All(a => a.ProductId != productId))
            .ToList();

        ViewBag.UnassociatedCategories = UnassociatedCategories;
        return View("detail", product);

    }

    [HttpPost("products/addcategory")]
    public IActionResult AddCategory(int Id, int prodId)
    {
        // Category? retrievedCategory = db.Categories.FirstOrDefault(c => c.CategoryId == Id);
        // Product? currentProduct = db.Products.FirstOrDefault(p => p.ProductId == HttpContext.Session.GetInt32("ProductId"));
        Association newAssociation = new Association();
        newAssociation.CategoryId = Id;
        newAssociation.ProductId = prodId;
        // newAssociation.Category = retrievedCategory;
        // newAssociation.Product = currentProduct;
        db.Associations.Add(newAssociation);
        db.SaveChanges();
        return RedirectToAction("Detail", new { ProductID = prodId });
    }

}