using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
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

    // public async Task<ActionResult> Index()
    // {
    //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //   var currentUser = await _userManager.FindByIdAsync(userId);
    //   var usersStudent = _db.Students.Where(entry => entry.User.Id == currentUser.Id).ToList();
    //   return View(usersStudent);
    // }
    // public ActionResult Index()
    // {
    //   return View(_db.Students.ToList());
    // }

    // [HttpPost]
    // public async Task<ActionResult> Create(Student Student)
    // {
    //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //   var currentUser = await _userManager.FindByIdAsync(userId);
    //   Student.User = currentUser;
    //   _db.Students.Add(Student);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    public ActionResult Create()
    {
      return View();
    }
    public ActionResult Details(int id)
    {
      var thisStudent = _db.Students
        .Include(s => s.JoinEntitiesCS)
        .ThenInclude(j => j.Course)
        .FirstOrDefault(s => s.StudentId == id);
      return View(thisStudent);
    }

    public ActionResult Edit(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(s => s.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult Edit(Student student)
    {
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index", "Account");
    }

    public ActionResult Delete(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(b => b.StudentId == id);
      _db.Students.Remove(thisStudent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCourse(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(s => s.StudentId == id);
      ViewBag.Courses = _db.Courses.ToList();
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddCourse(int StudentId, int CourseId)
    {
      if (CourseId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = StudentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteCourse(int joinIdCS)
    {
      var joinEntry = _db.CourseStudent.FirstOrDefault(entry => entry.CourseStudentId == joinIdCS);
      _db.CourseStudent.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult BuyWand(int studentId, string wand, string wandUrl)
    {
      if (studentId != 0)
      {
          var thisStudent = _db.Students.FirstOrDefault(s => s.StudentId == studentId);
          thisStudent.Wand = wand;
          thisStudent.WandURL = wandUrl;
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
