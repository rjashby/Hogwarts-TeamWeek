using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Hogwarts.Models;

namespace Hogwarts.Controllers
{
  public class ShopsController : Controller
  {
    private readonly HogwartsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public ShopsController(UserManager<ApplicationUser> userManager, HogwartsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpGet("/Shops")]
    public ActionResult DiagonAlley()
    {
      if (User.Identity.IsAuthenticated)
      {
        var model = _db.Students.FirstOrDefault(Student => Student.Email == User.Identity.Name);
        return View(model);
      }
      return View();
    }
    public ActionResult Ollivanders()
    {
      if (User.Identity.IsAuthenticated)
      {
        ViewBag.ThisStudentId = _db.Students.FirstOrDefault(Student => Student.Email == User.Identity.Name).StudentId;
      }
      return View();
    }
    public ActionResult Apothecary()
    {
      return View();
    }
    public ActionResult Cauldron()
    {
      return View();
    }
    public ActionResult Malkins()
    {
      if (User.Identity.IsAuthenticated)
      {
        ViewBag.Student = _db.Students.FirstOrDefault(Student => Student.Email == User.Identity.Name);
      }
      return View();
    }
    public ActionResult Menagerie()
    {
      return View();
    }
    public ActionResult Owl()
    {
      return View();
    }
    public ActionResult Quidditch()
    {
      return View();
    }
    public ActionResult FlourishAndBlotts()
    {
      return View();
    }
    public ActionResult Wiseacres()
    {
      return View();
    }
  }
}
