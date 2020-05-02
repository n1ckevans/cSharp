using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Dojodachi.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        // Get Dojodachi information from session and initialize default values
        Dachi myDachi = HttpContext.Session.GetObjectFromJson<Dachi>("myDachi");
        ViewBag.Status = "active";
        ViewBag.Reaction = "";
        ViewBag.Message = "Welcome to Dojodachi. Select an option below!";
        // If no myDachi instance exists, create one and start the game
        if (myDachi == null)
        {
            myDachi = new Dachi();
            HttpContext.Session.SetObjectAsJson("myDachi", new Dachi());
        }
        // Save myDachi to ViewBag session
        ViewBag.Dojodachi = myDachi;
        return View();
    }

        // Player pressed interaction button
        [HttpPost]
        [Route("action")]
        public IActionResult Action(string action)
        {
            // Fetch Dojodachi information from session
            Dachi myDachi = HttpContext.Session.GetObjectFromJson<Dachi>("myDachi");
            // Default values
            Random GameRandom = new Random();
            ViewBag.Status = "active";
            // Logic for button interactions
            switch(action)
            {
                case "Feed":
                    if (myDachi.Meals > 0)
                    {
                        myDachi.Meals--;
                        int RandomChance = GameRandom.Next(1, 5);
                        if (RandomChance == 1)
                        {
                            ViewBag.Reaction = "Your Dojodachi does not like this food";
                        }
                        else
                        {
                            myDachi.Fullness += GameRandom.Next(5, 11);
                            ViewBag.Reaction = "Your Dojodachi loves this food!";
                        }
                    }
                    else
                    {
                        ViewBag.Reaction = "You have no food left to feed Dojodachi";
                    }
                    break;
                case "Play":
                    if (myDachi.Energy > 0)
                    {
                        int RandomChance = GameRandom.Next(1, 5);
                        if (RandomChance == 1)
                        {
                            myDachi.Energy -= 5;
                            ViewBag.Reaction = "Dojodachi doesn't want to play right now.";
                        }
                        else
                        {
                            myDachi.Energy -= 5;
                            myDachi.Happiness += GameRandom.Next(5, 11);
                            ViewBag.Reaction = "Dojodachi is happy to play with you!";
                        }
                    }
                    else
                    {
                        ViewBag.Reaction = "Dojodachi is feeling too lazy to play. Needs more energy first.";
                    }
                    break;
                case "Work":
                    if (myDachi.Energy > 0)
                    {
                        myDachi.Energy -= 5;
                        myDachi.Meals += GameRandom.Next(1, 4);
                        ViewBag.Reaction = "Dojodachi reluctantly goes to work...";
                    }
                    else
                    {
                        ViewBag.Reaction = "Dojodachi tried to go to work, but had no energy and fell asleep instead.";
                    }
                    break;
                case "Sleep":
                    myDachi.Energy += 15;
                    myDachi.Fullness -= 5;
                    myDachi.Happiness -= 5;
                    ViewBag.Reaction = "Dojodachi takes a nap";
                    break;
                default:
                    ViewBag.Message = "Sleep is awesome!";
                    break;
            }
            // Player won the game
            if (myDachi.Energy >= 100 && myDachi.Fullness >= 100 && myDachi.Happiness >= 100)
            {
                ViewBag.Status = "Gameover";
                ViewBag.Reaction = "";
                ViewBag.Message = "You win!";
            }
            // Player lost the game
            else if (myDachi.Fullness <= 0 || myDachi.Happiness <= 0)
            {
                ViewBag.Status = "Gameover";
                ViewBag.Reaction = "";
                ViewBag.Message = "You lose!";
            }
            // Save myDachi information to session
            HttpContext.Session.SetObjectAsJson("myDachi", myDachi);
            ViewBag.Dojodachi = myDachi;
            return View("Index");
        }

        // Player pressed "Play Again?" button
        [HttpPost]
        [Route("reset")]
        public IActionResult Reset()
        {
            // Reset the game by clearing session, then redirect to Dojodachi
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }

    // Provided code to use Json data for session
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value= session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}