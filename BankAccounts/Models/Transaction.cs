using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace BankAccounts.Models
{
  public class Transaction
  {

    [Key]
    public int TransactionID { get; set; }

    [Required]
    public double Amount { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

  }
}