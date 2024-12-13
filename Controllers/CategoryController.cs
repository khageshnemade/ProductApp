using Microsoft.AspNetCore.Mvc;
using ProductApp.Data;
using ProductApp.Models;

namespace ProductApp.Controllers
{
 public class CategoryController : Controller
 {
  private readonly AppDbContext _context;

  public CategoryController(AppDbContext appDbContext)
  {
   _context = appDbContext;
  }

  public IActionResult Index()
  {
   var categories = _context.Categories.ToList();
   return View(categories);
  }
  public IActionResult Create()
  {
   return View();
  }
  [HttpPost, ValidateAntiForgeryToken]
  public IActionResult Create(Category category)
  {
   if (ModelState.IsValid) { _context.Categories.Add(category); _context.SaveChanges(); return RedirectToAction(nameof(Index)); }
   return View(category);
  }

  public IActionResult Edit(int id)
  {
   var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
   return View(category);
  }
  [HttpPost, ValidateAntiForgeryToken]
  public IActionResult Edit(Category category)
  {
   if (category != null)
   {
    _context.Update(category); _context.SaveChanges(); return RedirectToAction(nameof(Index));
   }
   return View(category);
  }
  public IActionResult Delete(int id)
  {
   var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
   return View(category);
  }

  [HttpPost, ValidateAntiForgeryToken]
  public IActionResult Delete(Category category)
  {
   if (category != null)
   {
    _context.Categories.Remove(category); _context.SaveChanges();
    return RedirectToAction(nameof(Index));
   }
   return View(category);
  }
 }
}
