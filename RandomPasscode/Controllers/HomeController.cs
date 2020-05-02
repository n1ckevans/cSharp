using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {

      HttpContext.Session.SetInt32("passcode", 1);
      int? passcode_int = HttpContext.Session.GetInt32("passcode");
      ViewBag.Count = passcode_int;

      var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      var stringChars = new char[14];
      var random = new Random();

      for (int i = 0; i < stringChars.Length; i++)
      {
        stringChars[i] = chars[random.Next(chars.Length)];
      }

      var finalString = new String(stringChars);
      ViewBag.Pass = finalString;


      return View();
    }

    [HttpPost]
    [Route("generate")]
    public IActionResult Generate()
    {
      int? passcode_int = HttpContext.Session.GetInt32("passcode");
      HttpContext.Session.SetInt32("passcode", (int)passcode_int +1);
      int? num = HttpContext.Session.GetInt32("passcode");
      ViewBag.Count = num;

      var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      var stringChars = new char[14];
      var random = new Random();

      for (int i = 0; i < stringChars.Length; i++)
      {
        stringChars[i] = chars[random.Next(chars.Length)];
      }

      var finalString = new String(stringChars);
      ViewBag.Pass = finalString;


      return View();
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
