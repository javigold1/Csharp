#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ChefsDishes.Models;
public class ChefsDishesContext : DbContext
{
    public ChefsDishesContext(DbContextOptions options) : base(options) { }

    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Chef> Chefs { get; set; }

}