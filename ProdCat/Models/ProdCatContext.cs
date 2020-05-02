using Microsoft.EntityFrameworkCore;

namespace ProdCat.Models
{
  public class ProdCatContext : DbContext
  {
    public ProdCatContext(DbContextOptions options) : base(options) { }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Association> Associations { get; set; }

  }
}