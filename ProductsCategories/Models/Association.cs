#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsCategories.Models;

public class Association
{
    [Key]
    public int AssociationID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public int CategoryId { get; set; }
    public Category? category { get; set; }
    public int ProductId { get; set; }
    public Product? product { get; set; }

}

