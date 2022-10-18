// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models;

public class Wedding
{
    public class WedDate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime formDate = Convert.ToDateTime(value);
            DateTime cutOff = DateTime.Now;
            if (formDate > cutOff)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Wedding date must be in the future.");
            }
        }

    }
    [Key]
    public int WeddingId { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Wedder One")]
    public string WedderOne { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Wedder Two")]
    public string WedderTwo { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Date")]
    [WedDate]
    public DateTime WeddingDate { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Address")]
    public string Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public User? Planner { get; set; }


    public List<Association> RsvpAssociation { get; set; } = new List<Association>();


}