using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;


namespace FormSubmission.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost("user/create")]
    public IActionResult Create(User user)
    {
      if (ModelState.IsValid)
      {
        // do somethng!  maybe insert into db?  then we will redirect
        return RedirectToAction("Success");
      }
      else
      {
        // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
        return View("Index");
      }
    }
public IActionResult Success()
    {
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
