using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefsNDishesContext dbContext;
        public HomeController(ChefsNDishesContext context)
        {
          dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            
            List<Chef> AllChefs = dbContext.Chefs.Include(dish => dish.CreatedDishes).ToList();
            AllChefs.Reverse();
            return View(AllChefs);
        }

        [HttpGet("/dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(chef => chef.Chef).ToList();
            AllDishes.Reverse();
            return View(AllDishes);
        }

        [HttpGet("/newchef")]
        public IActionResult NewChef()
        {
          Chef newChef = new Chef();
          return View(newChef);
        }

        [HttpPost("/createchef")]
        public IActionResult CreateChef(Chef newChef)
        {
          if (!ModelState.IsValid)
            {
              
              return View("NewChef");
            }
          dbContext.Chefs.Add(newChef);
          dbContext.SaveChanges();
          return RedirectToAction("Index");
          }


        [HttpGet("/newdish")]
        public IActionResult NewDish()
        {
          NewDish viewModel = new NewDish();
          viewModel.Dish = new Dish();
          viewModel.Chefs = dbContext.Chefs.ToList();
          return View(viewModel);
        }

        [HttpPost("/createdish")]
        public IActionResult CreateDish(NewDish viewModel)
        {
            Dish newDish = viewModel.Dish;

          if (!ModelState.IsValid)
            {
              
              return RedirectToAction("NewDish");
            }
        
          dbContext.Dishes.Add(newDish);
          dbContext.SaveChanges();
          return RedirectToAction("Dishes");
          }
    }
}
