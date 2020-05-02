using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdCat.Models;

namespace ProdCat.Controllers
{
  public class HomeController : Controller
  {

    private ProdCatContext dbContext;
    public HomeController(ProdCatContext context)
    {
      dbContext = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      ViewBag.AllProds = dbContext.Products.ToList();
      ViewBag.AllProds.Reverse();
      return View();
    }


    [HttpPost("/newprod")]
    public IActionResult NewProd(Product newProd)
    {
      if (!ModelState.IsValid)
      {

        return View("Index");
      }
      dbContext.Products.Add(newProd);
      dbContext.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/{productid}")]
    public IActionResult Product(int productid)
    {

      ViewBag.CurrentProd = dbContext.Products.Include(c => c.AssocCats).FirstOrDefault(p => p.ProductId == productid);

      ViewBag.AddCats = dbContext.Categories.Include(c => c.AssocProds).Where(cp => !cp.AssocProds.Any(pc => pc.ProductId == productid));

      ViewBag.ShowCats = dbContext.Categories.Include(c => c.AssocProds).Where(cp => cp.AssocProds.Any(pc => pc.ProductId == productid));


      return View();
    }

    [HttpGet("category/{categoryid}")]
    public IActionResult Category(int categoryid)
    {
      
      ViewBag.CurrentCat = dbContext.Categories.Include(c => c.AssocProds).FirstOrDefault(p => p.CategoryId == categoryid);

      ViewBag.AddProds= dbContext.Products.Include(p => p.AssocCats).Where(pc => !pc.AssocCats.Any(c => c.CategoryId == categoryid));


      ViewBag.ShowProds= dbContext.Products.Include(p => p.AssocCats).Where(pc => pc.AssocCats.Any(c => c.CategoryId == categoryid));
      
      return View();
    }


    [HttpGet("/categories")]
    public IActionResult Categories()
    {
      ViewBag.AllCats = dbContext.Categories.ToList();
      ViewBag.AllCats.Reverse();
      return View();
    }

    [HttpPost("/newcat")]
    public IActionResult NewCat(Category newCat)
    {
      if (!ModelState.IsValid)
      {

        return View("Categories");
      }
      dbContext.Categories.Add(newCat);
      dbContext.SaveChanges();
      return RedirectToAction("Categories");
    }

    [HttpPost("/addprodcat")]
    public IActionResult AddProdCat(Association newAssoc)
    {
       int id = newAssoc.ProductId;

      
      if (dbContext.Associations.FirstOrDefault(p => p.ProductId == newAssoc.ProductId && p.CategoryId == newAssoc.CategoryId) != null)
      {
        return RedirectToAction("Product", new {productid = id});
      }

      dbContext.Associations.Add(newAssoc);
      dbContext.SaveChanges();
      return RedirectToAction("Product", new {productid = id});
    }

    

    [HttpPost("/addcatprod")]
    public IActionResult AddCatProd(Association newAssoc)
    {
       int id = newAssoc.CategoryId;

      
      if (dbContext.Associations.FirstOrDefault(c => c.CategoryId == newAssoc.CategoryId && c.ProductId == newAssoc.ProductId) != null)
      {
        return RedirectToAction("Category", new {categoryid = id});
      }

      dbContext.Associations.Add(newAssoc);
      dbContext.SaveChanges();
      return RedirectToAction("Category", new {categoryid = id});
    }

  }
}
