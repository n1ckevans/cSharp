using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValidation.Models;


namespace DojoSurveyValidation.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost("result")]
    public IActionResult Result(string Name, string Locations, string Languages, string Comments)
    {
      Models.Survey info = new Models.Survey(Name, Locations, Languages, Comments);
      TryValidateModel(info);

      if (ModelState.IsValid)
      {
        return View("result", info);
      }
      else
      {
        return View("index");
      }

    }
  }
}
