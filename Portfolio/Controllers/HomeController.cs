using Microsoft.AspNetCore.Mvc;
namespace Portfolio.Controllers     //be sure to use your own project's namespace!
{
  public class HelloController : Controller   //remember inheritance??
  {
    //for each route this controller is to handle:
    [HttpGet("")]       //type of request
    public IActionResult Index()
    {
      return View();
    }

    [HttpGet("projects")]       //type of request
    public ViewResult Projects()
    {
      return View();
    }

    [HttpGet("contact")]       //type of request
    public ViewResult Contact()
    {
      return View();
    }

    [HttpPost]
        [Route("results")]
        public IActionResult Results(string name, string dojo_location, string fav_lang, string comment)
        {
            ViewBag.name = name;
            ViewBag.dojo_location = dojo_location;
            ViewBag.fav_lang = fav_lang;
            ViewBag.comments = comment;
            return View();
        }

  }
}
