#pragma warning disable CS8618
/* 
Disabled Warning: "Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable."
We can disable this safely because we know the framework will assign non-null values when it constructs this class for us.
*/
using Microsoft.EntityFrameworkCore;
namespace CRUDelicious.Models;
public class CrudeliciousContext : DbContext
{
    public CrudeliciousContext(DbContextOptions options) : base(options) { }

    public DbSet<Dish> Dishes { get; set; }

}