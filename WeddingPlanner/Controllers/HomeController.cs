using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlanner.Controllers
{
  public class HomeController : Controller
  {

    private WeddingPlannerContext _db;
    private int? _uid
    {
      get
      {
        return HttpContext.Session.GetInt32("UserId");
      }
    }
    public HomeController(WeddingPlannerContext context)
    {
      _db = context;
    }
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Register(User newUser)
    {
      if (ModelState.IsValid)
      {
        bool isEmailTaken =
            _db.Users.Any(user => newUser.Email == user.Email);

        if (isEmailTaken)
        {
          ModelState.AddModelError("Email", "Email Taken");
        }
      }

      if (ModelState.IsValid == false)
      {
        return View("Index");
      }

      PasswordHasher<User> hasher = new PasswordHasher<User>();
      newUser.Password = hasher.HashPassword(newUser, newUser.Password);

      _db.Users.Add(newUser);
      _db.SaveChanges();

      HttpContext.Session.SetInt32("UserId", newUser.UserId);
      return RedirectToAction("Dashboard");
    }

    public IActionResult Login(LoginUser loginUser)
    {
      if (ModelState.IsValid == false)
      {
        return View("Index");
      }
      else
      {
        User dbUser = _db.Users.FirstOrDefault(user => loginUser.LoginEmail == user.Email);

        if (dbUser == null)
        {
          ModelState.AddModelError("LoginEmail", "Invalid Credentials");
        }
        else
        {
          User viewUser = new User
          {
            Email = loginUser.LoginEmail,
            Password = loginUser.LoginPassword
          };

          PasswordHasher<User> hasher = new PasswordHasher<User>();

          PasswordVerificationResult result =
              hasher.VerifyHashedPassword(viewUser, dbUser.Password, viewUser.Password);

          // failed pw match
          if (result == 0)
          {
            ModelState.AddModelError("LoginEmail", "Invalid Credentials");
          }
          else
          {
            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
          }
        }
      }
      if (ModelState.IsValid == false)
      {
        // display error messages
        // on the forum they came from
        return View("Index");
      }

      return RedirectToAction("Dashboard");
    }


    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
      int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      // ViewBag.GuestList = _db.GuestLists.FirstOrDefault(g => g.Attendee.UserId == uid);
      // ViewBag.NotGuestList = _db.GuestLists.FirstOrDefault(g => g.Attendee.UserId != uid);
      ViewBag.User = _db.Users.FirstOrDefault(u => u.UserId == uid);
      ViewBag.AllWeds = _db.Weddings.Include(w => w.Guests).ToList();
      ViewBag.AllWeds.Reverse();

      return View();
    }


    [HttpGet("/logout")]
    public IActionResult Logout()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("Index");
    }

    [HttpGet("/wedding")]
    public IActionResult Wedding()
    {
      int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      ViewBag.AllWeds = _db.Weddings.ToList();
      ViewBag.AllWeds.Reverse();

      return View();
    }

    [HttpPost("/newwed")]
    public IActionResult NewWed(Wedding newWed)
    {
      if (!ModelState.IsValid)
      {

        return View ("Wedding");
      }

      int? uid = _uid;


      newWed.Creator = _db.Users.FirstOrDefault(u => u.UserId == uid);
      _db.Weddings.Add(newWed);
      _db.SaveChanges();
      return RedirectToAction("Dashboard");
    }

    [HttpGet("/{weddingid}")]
    public IActionResult Details(int weddingid)
    {

      ViewBag.CurrentWed = _db.Weddings.Include(g => g.Guests).FirstOrDefault(w => w.WeddingId == weddingid);
      ViewBag.Guests = _db.GuestLists.Where(w => w.WeddingId == weddingid).Include(w => w.Attendee).ToList();


      return View();
    }

    [HttpGet("/delete/{weddingid}/")]
    public IActionResult Delete(int weddingid)
    {


      Wedding wedToDelete = _db.Weddings.FirstOrDefault(w => w.WeddingId == weddingid);

      _db.Weddings.Remove(wedToDelete);
      _db.SaveChanges();
      return RedirectToAction("Dashboard");
    }


    [HttpGet("/rsvp/{weddingid}")]
    public IActionResult RSVP(int weddingid)
    {

      User currentUser = _db.Users.Include(u => u.Events).FirstOrDefault(u => u.UserId == _uid);
      Wedding currentWedding = _db.Weddings.Include(g => g.Guests).FirstOrDefault(w => w.WeddingId == weddingid);
      GuestList newList = new GuestList();

      newList.UserId = currentUser.UserId;
      newList.WeddingId = currentWedding.WeddingId;
      _db.GuestLists.Add(newList);
      _db.SaveChanges();

      return RedirectToAction("Dashboard");
    }

    [HttpGet("/unrsvp/{weddingid}")]
    public IActionResult UNRSVP(int weddingid)
    {

      User currentUser = _db.Users.Include(u => u.Events).FirstOrDefault(u => u.UserId == _uid);
      Wedding currentWedding = _db.Weddings.Include(g => g.Guests).FirstOrDefault(w => w.WeddingId == weddingid);
      GuestList currentList = _db.GuestLists.FirstOrDefault(u => u.UserId == currentUser.UserId && u.WeddingId == currentWedding.WeddingId);


      _db.GuestLists.Remove(currentList);
      _db.SaveChanges();

      return RedirectToAction("Dashboard");
    }


  }
}
