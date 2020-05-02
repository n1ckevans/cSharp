using System;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
  public class Quote
  {

    [Required]
    [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
    public string Name { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
  }
}