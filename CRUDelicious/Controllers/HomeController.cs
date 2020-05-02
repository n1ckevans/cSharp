using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private DishContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public HomeController(DishContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.ToList();
            AllDishes.Reverse();
            
            return View(AllDishes);
        }

        [HttpGet]
        [Route("/add")]
        public IActionResult New()
        {
          return View();
        }

        [HttpGet]
        [Route("/cancel")]
        public IActionResult Cancel()
        {
          return View("Index");
        }

       [HttpPost("/create")]
        public IActionResult Create(Dish newDish)
        {
          if (!ModelState.IsValid)
            {
              
              return View("New");
            }
          dbContext.Dishes.Add(newDish);
          dbContext.SaveChanges();
          return RedirectToAction("Index");
          }
        

        [HttpGet("/details/{id}")]
        public IActionResult Details(int id)
        {
            Dish selectedDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);

            if (selectedDish == null)
              {
                RedirectToAction("Index");
              }
           
            return View(selectedDish);
        }

        [HttpGet("/edit/{id}")]
        public IActionResult Edit(int id)
        {
          Dish toEdit = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);

            if (toEdit == null)
                return RedirectToAction("Index");

            return View(toEdit);
        }

        [HttpPost("/update/{id}")]
        public IActionResult Update(Dish editedDish, int id)
        {

            if (ModelState.IsValid)
            {
                Dish dbDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);

                if (dbDish != null)
                {
                    dbDish.Name = editedDish.Name;
                    dbDish.Chef = editedDish.Chef;
                    dbDish.Tastiness = editedDish.Tastiness;
                    dbDish.Calories = editedDish.Calories;
                    dbDish.Description = editedDish.Description;
                    dbDish.UpdatedAt = DateTime.Now;

                    dbContext.Dishes.Update(dbDish);
                    dbContext.SaveChanges();


                    return RedirectToAction("Index");
                }
            }
            // so error messages will be displayed if any
            return View("Edit", editedDish);
        }

        [HttpGet("/delete/{id}")]
        public IActionResult Delete(int id)
        {
        if (ModelState.IsValid)
            {
                Dish dbDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);

                if (dbDish != null)
                {
                    

                    dbContext.Dishes.Remove(dbDish);
                    dbContext.SaveChanges();


                    return RedirectToAction("Index");
                }
            }
            // so error messages will be displayed if any
            return View("Edit");
        }
    


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
