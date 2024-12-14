using ProductApp.Models;

namespace ProductApp.Services
{
 public interface ICategoryService
 {
  Task<IEnumerable<Category>> GetAllCategoriesAsync();
  Task<Category> GetCategoryByIdAsync(int id);
  Task<bool> CreateCategoryAsync(Category category);
  Task<bool> UpdateCategoryAsync(Category category);
  Task<bool> DeleteCategoryAsync(int id);
 }
}
