using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using ProductApp.Services;

namespace ProductApp.Controllers
{
 public class CategoryController : Controller
 {
  private readonly ICategoryService _categoryService;

  public CategoryController(ICategoryService categoryService)
  {
   _categoryService = categoryService;
  }

  public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
  {
   var categories = await _categoryService.GetAllCategoriesAsync();

   int totalCount = categories.Count();
   ViewBag.TotalCount = totalCount;

   var pagedCategories = categories
       .Skip((page - 1) * pageSize)
       .Take(pageSize)
       .ToList();

   ViewBag.CurrentPage = page;
   ViewBag.PageSize = pageSize;
   ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

   return View(pagedCategories);
  }

  public IActionResult Create()
  {
   return View();
  }

  [HttpPost, ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(Category category)
  {
   if (ModelState.IsValid)
   {
    var allCategories = await _categoryService.GetAllCategoriesAsync();
    bool isDuplicate = allCategories.Any(c => c.CategoryName == category.CategoryName);

    if (isDuplicate)
    {
     ModelState.AddModelError("CategoryName", "This category already exists.");
     return View(category);
    }

    bool result = await _categoryService.CreateCategoryAsync(category);
    if (result)
     return RedirectToAction(nameof(Index));
   }

   return View(category);
  }

  public async Task<IActionResult> Edit(int id)
  {
   var category = await _categoryService.GetCategoryByIdAsync(id);
   if (category == null)
    return NotFound();

   return View(category);
  }

  [HttpPost, ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(Category category)
  {
   if (ModelState.IsValid)
   {
    var originalCategory = await _categoryService.GetCategoryByIdAsync(category.CategoryId);
    if (originalCategory == null) return NotFound();
    if (originalCategory.CategoryName == category.CategoryName)
    {
     ModelState.AddModelError("", "No changes detected. Please modify the Category details.");
     return View(category);
    }
    bool result = await _categoryService.UpdateCategoryAsync(category);
    if (result)
     return RedirectToAction(nameof(Index));
   }

   return View(category);
  }

  public async Task<IActionResult> Delete(int id)
  {
   var category = await _categoryService.GetCategoryByIdAsync(id);
   if (category == null)
    return NotFound();

   return View(category);
  }

  [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
   bool result = await _categoryService.DeleteCategoryAsync(id);
   if (result)
    return RedirectToAction(nameof(Index));

   return RedirectToAction(nameof(Delete), new { id });
  }
 }
}
