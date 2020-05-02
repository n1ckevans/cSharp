using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LogReg.Controllers
{
  public class HomeController : Controller
  {

    private LogRegContext _db;
    private int? _uid
    {
      get
      {
        return HttpContext.Session.GetInt32("UserId");
      }
    }
    public HomeController(LogRegContext context)
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
      return RedirectToAction("Success");
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

      return RedirectToAction("Success");
    }

    public IActionResult Success()
    {
      int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index");
      }

      return View();
    }


    [HttpGet("/logout")]
    public IActionResult Logout()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("Index");
    }

  }
}
