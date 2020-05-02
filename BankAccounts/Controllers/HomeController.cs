using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BankAccounts.Controllers
{
  public class HomeController : Controller
  {



    private BankAccountsContext _db;
    private int? _uid
    {
      get
      {
        return HttpContext.Session.GetInt32("UserId");
      }
    }
    public HomeController(BankAccountsContext context)
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
          ModelState.AddModelError("Email", "Invalid Credentials");
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
      return RedirectToAction("Account");
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
        return View("Index");
      }

      return RedirectToAction("Account");
    }

    public IActionResult Account()
    {

      if (HttpContext.Session.GetInt32("UserId") == null)
      {
        return RedirectToAction("Index");
      }
      var userId = HttpContext.Session.GetInt32("UserId");
      var currentUser = _db.Transactions.Where(t => t.UserId == userId).OrderByDescending(t => t.CreatedAt).ToList();
      var user = _db.Users.FirstOrDefault(n => n.UserId == userId);
      ViewBag.Balance = user.AccountBalance;
      ViewBag.Name = user.FullName();


      return View(new TransactionViewModel { Transactions = currentUser });
    }


    [HttpPost]
    public IActionResult Transact(Transaction Transaction)
    {
      if (!ModelState.IsValid)
      {

        return View("Account");
      }
      var userId = HttpContext.Session.GetInt32("UserId");
      var user = _db.Users.FirstOrDefault(n => n.UserId == userId);
      var currentUser = _db.Transactions.Where(t => t.UserId == userId).OrderByDescending(t => t.CreatedAt).ToList();
            
      
      Transaction newTrans = new Transaction()
      {
        Amount = (int)Transaction.Amount,
        UserId = (int)HttpContext.Session.GetInt32("UserId"),
      };

   if (user.AccountBalance + (int)Transaction.Amount < 0)
      {
        ViewBag.Balance = user.AccountBalance;
        ViewBag.Name = user.FullName();
        TransactionViewModel tmp = new TransactionViewModel {
          User = user,
          Transaction = newTrans,
          Transactions = currentUser
        };
        ModelState.AddModelError("Transaction.Amount", "Unable to process transaction");
        return View("Account", tmp);
      }


      user.AccountBalance += (int)Transaction.Amount;

   

      _db.Transactions.Add(newTrans);
      _db.SaveChanges();

      

      return RedirectToAction("Account");
    }


    [HttpGet("/logout")]
    public IActionResult Logout()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("Index");
    }

  }
}
