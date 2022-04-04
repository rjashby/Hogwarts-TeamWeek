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
    public class TeachersController : Controller
    {
      private readonly HogwartsContext _db;
      private readonly UserManager<ApplicationUser> _userManager;
      public TeachersController(UserManager<ApplicationUser> userManager, HogwartsContext db)
      {
        _userManager = userManager;
        _db = db;
      }
      
      public ActionResult Index()
      {
        List<Teacher> model = _db.Teachers.ToList();
        return View(model);
      }
      
      public ActionResult Create()
      {
        return View();
      }
      
      [HttpPost]
      public ActionResult Create(Teacher teacher)
      {
        _db.Teachers.Add(teacher);
        _db.SaveChanges();
        return RedirectToAction("Create");
      }
      
      public ActionResult Edit(int id)
      {
        Teacher teacher = _db.Teachers.Where(t => t.TeacherId == id).FirstOrDefault();
        return View(teacher);
      }
      
      [HttpPost]
      public ActionResult Edit(Teacher teacher)
      {
        _db.Entry(teacher).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
}