using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
 public class Category
 {
  [Key]
  public int CategoryId { get; set; }
  [Required]
  [StringLength(50, MinimumLength = 3, ErrorMessage = "Category must in 3 to 50 characters")]
  public string CategoryName { get; set; }
 }
}
