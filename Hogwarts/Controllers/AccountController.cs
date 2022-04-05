using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Hogwarts.Models;
using System.Threading.Tasks;
using Hogwarts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Hogwarts.Controllers
{
  public class AccountController : Controller
  {
    private readonly HogwartsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, HogwartsContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }

    // [HttpPost]
    // public async Task<ActionResult> Register(RegisterViewModel model)
    // {
    //   var user = new ApplicationUser { UserName = model.Email };
    //   var student = new Student { FirstName = model.FirstName, LastName = model.LastName, Title = model.Title };
    //   IdentityResult result = await _userManager.CreateAsync(user, model.Password);
    //   if (result.Succeeded)
    //   {
    //     return RedirectToAction("Index");
    //   }
    //   else
    //   {
    //     return View();
    //   }
    // }

    // [HttpPost]
    // public async Task<ActionResult> Register(RegisterViewModel model)
    // {
    //   var user = new ApplicationUser { UserName = model.Email };
    //   IdentityResult result = await _userManager.CreateAsync(user, model.Password);
    //   Student student = new Student { FirstName = model.FirstName, LastName = model.LastName, Title = model.Title };
    //   return RedirectToAction("Create", "Student", new { student = student });
    //   // if (result.Succeeded)
    //   // {
    //   //   //then log in the newly registered user
    //   //   Microsoft.AspNetCore.Identity.SignInResult loginResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
    //   //   Student student = new Student { FirstName = model.FirstName, LastName = model.LastName, Title = model.Title };
    //   //   return RedirectToAction("Create", "Student", new { student = student });
    //     //   if (loginResult.Succeeded)
    //     //   {
    //     //     // Console.WriteLine(this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    //     //     // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //     //     // var currentUser = await _userManager.FindByIdAsync(userId);
    //     //     // Console.WriteLine(currentUser);
    //     //     // , User = currentUser };
    //     //     // _db.Students.Add(student);
    //     //     // _db.SaveChanges();
    //     //     return RedirectToAction("Create", "Student", new { student = student });
    //     //   }
    //     //   else
    //     //   {
    //     //     return View();
    //     //   }
    //   // }
    //   // else
    //   // {
    //   //   return View();
    //   // }
    // }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);

      Microsoft.AspNetCore.Identity.SignInResult loginResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);

      Student student = new Student { FirstName = model.FirstName, LastName = model.LastName, Title = model.Title, Email = model.Email, Year = model.Year };

      _db.Students.Add(student);
      _db.SaveChanges();
      if (result.Succeeded)
      {
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return View();
      }
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
  }
}
