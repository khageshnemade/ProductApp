using Microsoft.EntityFrameworkCore;
using ProductApp.Models;

namespace ProductApp.Data
{
 public class AppDbContext : DbContext
 {
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Product> Products { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
   base.OnModelCreating(modelBuilder);
   modelBuilder.Entity<Category>().HasIndex(c => c.CategoryName).IsUnique().HasDatabaseName("C_Name_unique");
   modelBuilder.Entity<Product>().HasIndex(p => new { p.ProductName, p.CategoryId }).IsUnique().HasDatabaseName("p_Name_cid_unique");
  }
 }
}
