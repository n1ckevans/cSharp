using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccounts.Models
{
  public class User
  {
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "is required")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(8, ErrorMessage = "must be at least 8 characters")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    public double AccountBalance { get; set; } = 0;

    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "must match password")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }

    public List<Transaction> UserTransactions { get; set; } = new List<Transaction>();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public string FullName()
    {
      return FirstName + " " + LastName;
    }
  }
}