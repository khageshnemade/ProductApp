using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Models;

namespace ProductApp.Services
{
 public class CategoryService : ICategoryService
 {
  private readonly AppDbContext _context;

  public CategoryService(AppDbContext context)
  {
   _context = context;
  }

  public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
  {
   return await _context.Categories.ToListAsync();
  }

  public async Task<Category> GetCategoryByIdAsync(int id)
  {
   return await _context.Categories.FindAsync(id);
  }

  public async Task<bool> CreateCategoryAsync(Category category)
  {
   _context.Categories.Add(category);
   return await _context.SaveChangesAsync() > 0;
  }

  public async Task<bool> UpdateCategoryAsync(Category category)
  {
   _context.Categories.Update(category);
   return await _context.SaveChangesAsync() > 0;
  }

  public async Task<bool> DeleteCategoryAsync(int id)
  {
   var category = await _context.Categories.FindAsync(id);
   if (category == null) return false;

   _context.Categories.Remove(category);
   return await _context.SaveChangesAsync() > 0;
  }
 }

}
