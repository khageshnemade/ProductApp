using System.ComponentModel.DataAnnotations;

namespace ProductApp.viewModels
{
 public class ProductViewModel
 {
  [Key]
  public int ProductId { get; set; }
  [StringLength(200, MinimumLength = 3, ErrorMessage = "{0} must be between 3 and 200 characters")]

  public string ProductName { get; set; }
  public int CategoryId { get; set; }
  public string CategoryName { get; set; }
 }
}
