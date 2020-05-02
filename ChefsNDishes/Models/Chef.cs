using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace ChefsNDishes.Models
{
  public class Chef
  {
    [Key]
    public int ChefId { get; set; }

    [Required(ErrorMessage = "Please enter Chef's ")]
    [MinLength(2)]
    public string Name { get; set; }
    
    [Required]
    public DateTime? Birthday { get; set; }
    
    public List<Dish> CreatedDishes { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; } = DateTime.Now;



  }
}