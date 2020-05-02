using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
  public class WordController : Controller
  {
    [HttpGet]       //type of request
    [Route("")]     //associated route string (exclude the leading /)
    public IActionResult Index()
    {
      Word dodgers = new Word()
      {
        Name = "Los Angeles Dodgers Baseball",
      };
      
       Word rams = new Word()
      {
        Name = "Los Angeles Rams Football",
      };
  
   Word lakers = new Word()
      {
        Name = "Los Angeles Lakers Basketball",
      };
       Word kings = new Word()
      {
        Name = "Los Angeles Kings Hockey",
      };

 List<Word> sports = new List<Word>()
  {
    dodgers, rams, lakers, kings
  };

      return View(sports);
    }
  }
}