using Microsoft.AspNetCore.Mvc;
using ProductApp.Data;
using ProductApp.Models;
using ProductApp.viewModels;

namespace ProductApp.Controllers
{
 public class ProductController : Controller
 {
  private readonly AppDbContext _context;

  public ProductController(AppDbContext context)
  {
   _context = context;
  }

  public IActionResult Index(int page = 1, int pageSize = 10)
  {
   int totalCount = _context.Products.Count();
   ViewBag.TotalCount = totalCount;

   var products = _context.Products
     .Join(
         _context.Categories,
         p => p.CategoryId,
         c => c.CategoryId,
         (p, c) => new ProductViewModel
         {
          ProductId = p.ProductId,
          ProductName = p.ProductName,
          CategoryId = p.CategoryId,
          CategoryName = c.CategoryName
         }
     )
     .Skip((page - 1) * pageSize)
     .Take(pageSize)
     .ToList();


   ViewBag.CurrentPage = page;
   ViewBag.PageSize = pageSize;
   ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

   return View(products);
  }


  public IActionResult Create()
  {
   ViewBag.categories = _context.Categories.ToList();
   return View();
  }
  [HttpPost, ValidateAntiForgeryToken]
  public IActionResult Create(Product product)
  {
   if (product != null && product.ProductName != null && product.CategoryId != null)
   {
    product.Category = _context.Categories.FirstOrDefault(p => p.CategoryId == product.CategoryId);
    _context.Products.Add(product);
    _context.SaveChanges(); return RedirectToAction(nameof(Index));
   }
   ViewBag.categories = _context.Categories.ToList();
   return View(product);
  }
  [HttpGet]
  public IActionResult Edit(int id)
  {
   var product = _context.Products
       .Where(p => p.ProductId == id)
       .Select(p => new ProductViewModel
       {
        ProductId = p.ProductId,
        ProductName = p.ProductName,
        CategoryId = p.CategoryId,
        CategoryName = p.Category.CategoryName
       })
       .FirstOrDefault();

   if (product == null)
   {
    return NotFound();
   }

   ViewBag.Categories = _context.Categories
       .Select(c => new { c.CategoryId, c.CategoryName })
       .ToList();

   return View(product);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Edit(ProductViewModel model)
  {
   if (ModelState.IsValid)
   {
    var product = _context.Products.Find(model.ProductId);
    if (product == null)
    {
     return NotFound();
    }

    product.ProductName = model.ProductName;
    product.CategoryId = model.CategoryId;

    _context.SaveChanges();
    return RedirectToAction("Index");
   }

   ViewBag.Categories = _context.Categories
       .Select(c => new { c.CategoryId, c.CategoryName })
       .ToList();

   return View(model);
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
   var product = _context.Products
       .Where(p => p.ProductId == id)
       .Select(p => new ProductViewModel
       {
        ProductId = p.ProductId,
        ProductName = p.ProductName,
        CategoryId = p.CategoryId,
        CategoryName = _context.Categories
               .Where(c => c.CategoryId == p.CategoryId)
               .Select(c => c.CategoryName)
               .FirstOrDefault()
       })
       .FirstOrDefault();

   if (product == null)
   {
    return NotFound();
   }

   return View(product);
  }

  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public IActionResult DeleteConfirmed(int id)
  {
   var product = _context.Products.Find(id);
   if (product == null)
   {
    return NotFound();
   }

   _context.Products.Remove(product);
   _context.SaveChanges();

   return RedirectToAction("Index");
  }

 }
}
