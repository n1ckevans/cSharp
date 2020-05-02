using System.ComponentModel.DataAnnotations;
using System;

namespace CRUDelicious.Models
{
  public class Dish
  {
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage = "Please enter Dish ")]
    [MinLength(2)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Please enter the Dish's")]
    [MinLength(2)]
    public string Chef { get; set; }
    
    [Required]
    [Range(0, 5, ErrorMessage = "Must be between 1-5")]
    public int Tastiness { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Calories { get; set; }
    
    [Required(ErrorMessage = "Please enter a ")]
    [MinLength(2)]
    public string Description { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; } = DateTime.Now;



  }
}