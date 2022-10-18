#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Association
{
    [Key]
    public int AssociationID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public int WeddingId { get; set; }
    public Wedding? wedding { get; set; }
    public int UserId { get; set; }
    public User? user { get; set; }

}