using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
  public class ECommerceContext : DbContext
  {
    public ECommerceContext(DbContextOptions options) : base(options) { }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Association> Associations { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Order> Orders { get; set; }
  }
}