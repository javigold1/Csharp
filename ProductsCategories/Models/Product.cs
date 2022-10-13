#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsCategories.Models;


public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "is required")]
    public string Description { get; set; }

    [Required(ErrorMessage = "is required")]
    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // List<Category> ProductCategory { get; set; } = new List<Category>();
    public List<Association> ProductCategories { get; set; } = new List<Association>();


}