using System.ComponentModel.DataAnnotations;
using System;

namespace ChefsNDishes.Models
{
  public class Dish
  {
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage = "Please enter Dish ")]
    [MinLength(2)]
    public string Name { get; set; }
    public Chef Chef { get; set; }
    
    [Required]
    [Range(0, 5, ErrorMessage = "Enter level of ")]
    public int Tastiness { get; set; }

    [Required(ErrorMessage = "Must enter number of ")]
    [Range(0, int.MaxValue)]
    public int Calories { get; set; }
    
    [Required(ErrorMessage = "Please write a ")]
    [MinLength(2)]
    public string Description { get; set; }

    public int ChefId { get; set;}
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

  }
}