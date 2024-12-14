using Microsoft.AspNetCore.Mvc;
using ProductApp.Services;
using ProductApp.viewModels;


namespace ProductApp.Controllers
{
 public class ProductController : Controller
 {
  private readonly IProductService _productService;
  private readonly ICategoryService _categoryService;

  public ProductController(IProductService productService, ICategoryService categoryService)
  {
   _productService = productService;
   _categoryService = categoryService;
  }

  public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
  {
   var totalProducts = await _productService.GetTotalCountAsync();
   var products = await _productService.GetPagedProductsAsync(page, pageSize);

   ViewBag.CurrentPage = page;
   ViewBag.PageSize = pageSize;
   ViewBag.TotalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
   ViewBag.TotalCount = totalProducts;

   return View(products);
  }

  public async Task<IActionResult> Create()
  {
   var categories = await _categoryService.GetAllCategoriesAsync();
   ViewBag.Categories = categories;
   return View();
  }

  [HttpPost, ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(ProductViewModel model)
  {
   ModelState.Remove("CategoryName");
   if (ModelState.IsValid)
   {
    bool isDuplicate = await _productService.IsDuplicateProductAsync(model.ProductName, model.CategoryId);
    if (isDuplicate)
    {
     ModelState.AddModelError("ProductName", "Product already exists in the selected category.");
     ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
     return View(model);
    }

    bool result = await _productService.CreateProductAsync(model);
    if (result)
     return RedirectToAction(nameof(Index));
   }

   ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
   return View(model);
  }

  public async Task<IActionResult> Edit(int id)
  {
   var product = await _productService.GetProductByIdAsync(id);
   if (product == null)
    return NotFound();
   ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
   return View(product);
  }
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(ProductViewModel model)
  {
   if (ModelState.IsValid)
   {
    var originalProduct = await _productService.GetProductByIdAsync(model.ProductId);
    if (originalProduct == null)
    {
     return NotFound();
    }

    if (originalProduct.ProductName == model.ProductName && originalProduct.CategoryId == model.CategoryId)
    {
     ModelState.AddModelError("", "No changes detected. Please modify the product details.");
     ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
     return View(model);
    }

    var result = await _productService.UpdateProductAsync(model);
    if (result)
    {
     return RedirectToAction("Index");
    }
   }

   ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
   return View(model);
  }


  public async Task<IActionResult> Delete(int id)
  {
   var product = await _productService.GetProductByIdAsync(id);
   if (product == null)
    return NotFound();

   return View(product);
  }

  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
   bool result = await _productService.DeleteProductAsync(id);
   if (result)
    return RedirectToAction(nameof(Index));

   return RedirectToAction("Delete", new { id });
  }
 }
}
