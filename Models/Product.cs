using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApp.Models
{
 public class Product
 {
  [Key] public int ProductId { get; set; }
  [Required(ErrorMessage = "{0} is required")]
  [StringLength(200, MinimumLength = 3, ErrorMessage = "{0} must be between 3 and 200 characters")]
  public string ProductName { get; set; }

  [ForeignKey("Category")] public int CategoryId { get; set; }
  public virtual Category Category { get; set; }
 }
}
