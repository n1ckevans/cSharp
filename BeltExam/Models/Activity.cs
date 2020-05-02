using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam.Models
{
  public class Activity
  {
    [Key]
    public int ActivityId { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Time")]
    public DateTime Time { get; set; }

    [Required(ErrorMessage = "is required.")]
    [FutureDate(ErrorMessage="Date should be in the future.")]
    [Display(Name = "Date")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Duration")]
    public int Duration { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Length")]
    public string Length { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(10, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Description")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public User Creator { get; set; }

    public List<Event> Events { get; set; }

   

  }

  public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        return value != null && (DateTime)value > DateTime.Now;
    }
}
}