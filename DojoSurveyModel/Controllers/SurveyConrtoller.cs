using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyModel.Models;

namespace DojoSurveyModel.Controllers     //be sure to use your own project's namespace!
{
  public class SurveyController : Controller   //remember inheritance??
  {
    //for each route this controller is to handle:
    [HttpGet("")]       //type of request
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
        [Route("results")]
        public IActionResult Results(string Name, string Location, string Language, string Comment)
        {
          Survey result = new Survey(){
            Name = Name,
            Location = Location,
            Language = Language,
            Comment = Comment
          };

            ViewBag.name = result.Name;
            ViewBag.dojo_location = result.Location;
            ViewBag.fav_lang = result.Language;
            ViewBag.comments = result.Comment;
           
            return View();
        }

  }
}
