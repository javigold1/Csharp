#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsDishes.Models;

public class Chef
{
    public class MinAge : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime formDate = Convert.ToDateTime(value);
            DateTime cutOff = DateTime.Now.AddYears(-18);
            if (formDate < cutOff)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Must be at least 18 years of age");
            }
        }

    }
    [Key]
    public int ChefId { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be more than 2 characters")]
    [MaxLength(45, ErrorMessage = "must be less than 45 characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }


    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be more than 2 characters")]
    [MaxLength(45, ErrorMessage = "must be less than 45 characters")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Date of birth required")]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    [MinAge]
    public DateTime DOB { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> ChefDishes { get; set; } = new List<Dish>();

}