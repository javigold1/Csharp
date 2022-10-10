#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsDishes.Models;


public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be more than 2 characters")]
    [MaxLength(45, ErrorMessage = "must be less than 45 characters")]
    public string Name { get; set; }

    // [Required(ErrorMessage = "is required")]
    // // [MinLength(2, ErrorMessage = "must be more than 2 characters")]
    // // [MaxLength(45, ErrorMessage = "must be more than 45 characters")]
    // public int ChefId { get; set; }

    [Required(ErrorMessage = "is required")]
    [Range(1, 5, ErrorMessage = "Tastiness must be between 1-5")]
    public int Tastiness { get; set; }

    [Required(ErrorMessage = "is required")]
    [Range(0, 50000, ErrorMessage = "Calories must be > 0")]
    public int Calories { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int ChefId { get; set; }  //foriegn key
    public Chef? Author { get; set; } //the ONE user related to each Dish

}