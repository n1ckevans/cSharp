using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BeltExam.Controllers
{
  public class HomeController : Controller
  {

    private BeltExamContext _db;
    private int? _uid
    {
      get
      {
        return HttpContext.Session.GetInt32("UserId");
      }
    }
    public HomeController(BeltExamContext context)
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

      ViewBag.User = _db.Users.FirstOrDefault(u => u.UserId == uid);
      ViewBag.AllActs = _db.Activities.Include(w => w.Events).Include(u => u.Creator).OrderBy(x => x.Date).ToList();
     
     

      return View();
    }


    [HttpGet("/logout")]
    public IActionResult Logout()
    {

       int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      HttpContext.Session.Clear();
      return RedirectToAction("Index");
    }


    [HttpGet("/new")]
    public IActionResult New()
    {
      int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }
      
      ViewBag.AllActs = _db.Activities.ToList();
      ViewBag.AllActs.Reverse();

      return View();
    }
    
    [HttpPost("/newact")]
    public IActionResult NewAct(BeltExam.Models.Activity newAct)
    {
      
    
      int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      if (!ModelState.IsValid)
      {

        return View ("New");
      }

    


      newAct.Creator = _db.Users.FirstOrDefault(u => u.UserId == uid);
      _db.Activities.Add(newAct);
      _db.SaveChanges();
      return RedirectToAction("Activity", newAct);
    }

    [HttpGet("/activity/{activityid}")]
    public IActionResult Activity(int activityid)
    {
       int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      ViewBag.User = _db.Users.FirstOrDefault(u => u.UserId == uid);
      ViewBag.CurrentAct = _db.Activities.Include(e => e.Creator).FirstOrDefault(w => w.ActivityId == activityid);
      ViewBag.Guests = _db.Events.Where(w => w.ActivityId == activityid).Include(w => w.Attendee).ToList();


      return View();
    }


    [HttpGet("/dashboard/{activityid}/delete")]
    public IActionResult Delete(int activityid)
    {
       int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      BeltExam.Models.Activity actToDelete = _db.Activities.FirstOrDefault(w => w.ActivityId == activityid);

      _db.Activities.Remove(actToDelete);
      _db.SaveChanges();
      return RedirectToAction("Dashboard");
    }

    [HttpGet("/dashboard/{activityid}/join")]
    public IActionResult Join(int activityid)
    {
       int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      User currentUser = _db.Users.Include(u => u.Events).FirstOrDefault(u => u.UserId == _uid);
      BeltExam.Models.Activity currentAct = _db.Activities.Include(g => g.Events).FirstOrDefault(a => a.ActivityId == activityid);
      Event newEvent = new Event();

      // var allActs = _db.Events.Contains(u => u.Attendee.UserId == uid);

      // bool dateexists = allActs.Exists(e => e.Date == currentAct.Date);
      // bool durationexists = allActs.Exists(e => e.Duration == currentAct.Duration);

      //   if (dateexists && durationexists)
      //   {
      //     return RedirectToAction("Dashboard");
      //   }


        // else {

          newEvent.UserId = currentUser.UserId;
          newEvent.ActivityId = currentAct.ActivityId;
          _db.Events.Add(newEvent);
          _db.SaveChanges();

          return RedirectToAction("Dashboard");
        // }
    }

     [HttpGet("/dashboard/{activityid}/leave")]
    public IActionResult Leave(int activityid)
    {
       int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      User currentUser = _db.Users.Include(u => u.Events).FirstOrDefault(u => u.UserId == _uid);
      BeltExam.Models.Activity currentAct = _db.Activities.Include(g => g.Events).FirstOrDefault(a => a.ActivityId == activityid);
      Event currentEvent = _db.Events.FirstOrDefault(u => u.UserId == currentUser.UserId && u.ActivityId == currentAct.ActivityId);


      _db.Events.Remove(currentEvent);
      _db.SaveChanges();

      return RedirectToAction("Dashboard");
    }


    [HttpGet("/activity/{activityid}/delete")]
    public IActionResult DeleteActivity(int activityid)
    {
       int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      BeltExam.Models.Activity actToDelete = _db.Activities.FirstOrDefault(w => w.ActivityId == activityid);

      _db.Activities.Remove(actToDelete);
      _db.SaveChanges();
      return RedirectToAction("Dashboard");
    }


    [HttpGet("/activity/{activityid}/join")]
    public IActionResult JoinActivity(int activityid)
    {
       int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      User currentUser = _db.Users.Include(u => u.Events).FirstOrDefault(u => u.UserId == _uid);
      BeltExam.Models.Activity currentAct = _db.Activities.Include(g => g.Events).FirstOrDefault(a => a.ActivityId == activityid);
      Event newEvent = new Event();

      newEvent.UserId = currentUser.UserId;
      newEvent.ActivityId = currentAct.ActivityId;
      _db.Events.Add(newEvent);
      _db.SaveChanges();

      return RedirectToAction("Dashboard");
    }

    [HttpGet("/activity/{activityid}/leave")]
    public IActionResult LeaveActivity(int activityid)
    {
       int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      User currentUser = _db.Users.Include(u => u.Events).FirstOrDefault(u => u.UserId == _uid);
      BeltExam.Models.Activity currentAct = _db.Activities.Include(g => g.Events).FirstOrDefault(a => a.ActivityId == activityid);
      Event currentEvent = _db.Events.FirstOrDefault(u => u.UserId == currentUser.UserId && u.ActivityId == currentAct.ActivityId);


      _db.Events.Remove(currentEvent);
      _db.SaveChanges();

      return RedirectToAction("Dashboard");
    }

  }
}
