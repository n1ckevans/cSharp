using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleLoginRegistration.Models;

namespace SimpleLoginRegistration.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }


    [HttpPost("create/user")]
    public IActionResult CreateUser(RegUser newUser)
    {
      if (ModelState.IsValid)
      {
        return RedirectToAction("Success");
      }
      return View("Index");
    }


[HttpPost("login/user")]
    public IActionResult LoginUser(LogUser newUser)
    {
    if (ModelState.IsValid)
      {
        return RedirectToAction("Success");
      }
      return View("Index");
    }
    

[HttpGet("success")]
    public string Success()
    {
        return "S U C C E S S";
    }


    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
