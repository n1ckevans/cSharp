using System.ComponentModel.DataAnnotations;
using System;

namespace SimpleLoginRegistration.Models
{
  public class RegUser
  {

    [Required(ErrorMessage = "Please enter your First Name")]
    [MinLength(2)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter your Last Name")]
    [MinLength(2)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter your Email")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm Password")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }
  }

  public class LogUser
  {

    [Required(ErrorMessage = "Please enter your Email")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }


  }

}