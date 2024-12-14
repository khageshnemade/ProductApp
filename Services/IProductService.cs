using ProductApp.viewModels;

namespace ProductApp.Services
{
 public interface IProductService
 {
  Task<List<ProductViewModel>> GetPagedProductsAsync(int page, int pageSize);
  Task<int> GetTotalCountAsync();
  Task<bool> IsDuplicateProductAsync(string productName, int categoryId);
  Task<ProductViewModel> GetProductByIdAsync(int id);
  Task<bool> CreateProductAsync(ProductViewModel model);
  Task<bool> UpdateProductAsync(ProductViewModel model);
  Task<bool> DeleteProductAsync(int id);
 }
}
