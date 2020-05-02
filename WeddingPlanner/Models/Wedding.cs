using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
  public class Wedding
  {
    [Key]
    public int WeddingId { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    public string WedderOne { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    public string WedderTwo { get; set; }

    [Required(ErrorMessage = "is required.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    public string Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public User Creator { get; set; }

    public List<GuestList> Guests { get; set; }

    public string Names()
    {
      return WedderOne + " & " + WedderTwo;
    }

  }
}