#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsCategories.Models;


public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "is required")]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // public int ProductId { get; set; }
    // public Product? Prod { get; set; }
    public List<Association> CatagoryAss { get; set; } = new List<Association>();

}