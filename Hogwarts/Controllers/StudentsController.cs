using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Claims;
using Hogwarts.Models;

namespace Hogwarts.Controllers
{
  public class StudentsController : Controller
  {
    private readonly HogwartsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public StudentsController(UserManager<ApplicationUser> userManager, HogwartsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpPost]
    public ActionResult Edit(Student student)
    {
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index", "Account");
    }

    [HttpPost]
    public ActionResult BuyWand(int studentId, string wand, string wandURL)
    {
      if (studentId != 0)
      {
        Student thisStudent = _db.Students.FirstOrDefault(s => s.StudentId == studentId);
        thisStudent.Wand = wand;
        thisStudent.WandURL = wandURL;
        _db.Entry(thisStudent).State = EntityState.Modified;
        _db.SaveChanges();
      }

      return Json(new { Message = "message" });
    }

    [HttpPost]
    public ActionResult SelectRobe(string robe)
    {
      if (User.Identity.IsAuthenticated)
      {
        Student thisStudent = _db.Students.FirstOrDefault(Student => Student.Email == User.Identity.Name);
        thisStudent.Robes = robe;
        _db.Entry(thisStudent).State = EntityState.Modified;
        _db.SaveChanges();
      }
      Thread.Sleep(750);
      return RedirectToAction("Index", "Shops");
    }

    [HttpPost]
    public ActionResult Books(string booksString)
    {
      if (User.Identity.IsAuthenticated)
      {
        Student thisStudent = _db.Students.FirstOrDefault(Student => Student.Email == User.Identity.Name);
        thisStudent.Books = booksString.Remove(booksString.Length - 1, 1);
        _db.Entry(thisStudent).State = EntityState.Modified;
        _db.SaveChanges();
      }
      Thread.Sleep(750);
      return RedirectToAction("Index", "Shops");
    }

    [HttpPost]
    public ActionResult BuyAnimal(string animal)
    {
      if (User.Identity.IsAuthenticated)
      {
        Student thisStudent = _db.Students.FirstOrDefault(Student => Student.Email == User.Identity.Name);
        thisStudent.Animal = animal;
        _db.Entry(thisStudent).State = EntityState.Modified;
        _db.SaveChanges();
      }
      Thread.Sleep(750);
      return RedirectToAction("Index", "Shops");
    }

    [HttpPost]
    public ActionResult Tools(string telescope, string scale)
    {
      if (User.Identity.IsAuthenticated)
      {
        Student thisStudent = _db.Students.FirstOrDefault(Student => Student.Email == User.Identity.Name);
        if (telescope != null)
        {
          thisStudent.Tools = telescope;
        }
        if (scale != null)
        {
          thisStudent.Scale = scale;
        }
        _db.Entry(thisStudent).State = EntityState.Modified;
        _db.SaveChanges();
      }
      Thread.Sleep(750);
      return RedirectToAction("Index", "Shops");
    }

    [HttpPost]
    public ActionResult BuyPhials(string phials)
    {
      if (User.Identity.IsAuthenticated)
      {
        Student thisStudent = _db.Students.FirstOrDefault(Student => Student.Email == User.Identity.Name);
        thisStudent.Phials = phials;
        _db.Entry(thisStudent).State = EntityState.Modified;
        _db.SaveChanges();
      }
      Thread.Sleep(750);
      return RedirectToAction("Index", "Shops");
    }

    [HttpPost]
    public ActionResult BuyCauldron(string cauldron)
    {
      if (User.Identity.IsAuthenticated)
      {
        Student thisStudent = _db.Students.FirstOrDefault(Student => Student.Email == User.Identity.Name);
        thisStudent.Cauldron = cauldron;
        _db.Entry(thisStudent).State = EntityState.Modified;
        _db.SaveChanges();
      }
      Thread.Sleep(750);
      return RedirectToAction("Index", "Shops");
    }
  }
}
