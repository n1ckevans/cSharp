using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
  public class UserController : Controller
  {
    [HttpGet]       //type of request
    [Route("users")]     //associated route string (exclude the leading /)
    public IActionResult Users()
    {
      User john = new User()
      {
        FirstName = "John",
        LastName = "Lennon"
      };

      User paul = new User()
      {
        FirstName = "Paul",
        LastName = "McCartney"
      };

      User george = new User()
      {
        FirstName = "George",
        LastName = "Harrison"
      };

      User ringo = new User()
      {
        FirstName = "Ringo",
        LastName = "Starr"
      };

      List<User> beatles = new List<User>()
  {
    john, paul, george, ringo
  };

      return View(beatles);
    }

    [HttpGet]
    [Route("{person}")]
    public ViewResult VisitPlace(string person)
    {
      return View(person.Replace(" ", ""));
    }


    

  }
}