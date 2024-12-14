using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Models;
using ProductApp.viewModels;

namespace ProductApp.Services
{
 public class ProductService : IProductService
 {
  private readonly AppDbContext _context;

  public ProductService(AppDbContext context)
  {
   _context = context;
  }

  public async Task<List<ProductViewModel>> GetPagedProductsAsync(int page, int pageSize)
  {
   return await _context.Products
       .Join(_context.Categories,
             p => p.CategoryId,
             c => c.CategoryId,
             (p, c) => new ProductViewModel
             {
              ProductId = p.ProductId,
              ProductName = p.ProductName,
              CategoryId = p.CategoryId,
              CategoryName = c.CategoryName
             })
       .Skip((page - 1) * pageSize)
       .Take(pageSize)
       .ToListAsync();
  }

  public async Task<int> GetTotalCountAsync()
  {
   return await _context.Products.CountAsync();
  }

  public async Task<bool> IsDuplicateProductAsync(string productName, int categoryId)
  {
   return await _context.Products.AnyAsync(p => p.ProductName == productName && p.CategoryId == categoryId);
  }

  public async Task<ProductViewModel> GetProductByIdAsync(int id)
  {
   var product = await _context.Products
          .Where(p => p.ProductId == id)
          .Select(p => new ProductViewModel
          {
           ProductId = p.ProductId,
           ProductName = p.ProductName,
           CategoryId = p.CategoryId,
           CategoryName = p.Category.CategoryName
          })
          .FirstOrDefaultAsync() ?? new ProductViewModel();
   return product;
  }

  public async Task<bool> CreateProductAsync(ProductViewModel model)
  {
   var product = new Product
   {
    ProductName = model.ProductName,
    CategoryId = model.CategoryId,
    Category = await _context.Categories.FindAsync(model.CategoryId)
   };
   _context.Products.Add(product);
   return await _context.SaveChangesAsync() > 0;
  }

  public async Task<bool> UpdateProductAsync(ProductViewModel model)
  {
   var product = await _context.Products.FindAsync(model.ProductId);
   if (product == null)
    return false;

   product.ProductName = model.ProductName;
   product.CategoryId = model.CategoryId;

   _context.Products.Update(product);
   await _context.SaveChangesAsync();

   return true;
  }


  public async Task<bool> DeleteProductAsync(int id)
  {
   var product = await _context.Products.FindAsync(id);
   if (product == null) return false;

   _context.Products.Remove(product);
   return await _context.SaveChangesAsync() > 0;
  }
 }
}
