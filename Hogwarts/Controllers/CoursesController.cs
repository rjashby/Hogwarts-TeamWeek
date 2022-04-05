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
  public class CoursesController : Controller
  {
    private readonly HogwartsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public CoursesController(UserManager<ApplicationUser> userManager, HogwartsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      List<Course> model = _db.Courses.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course)
    {
      if (_db.Courses.Where(c => c.CourseName != course.CourseName).Any() == true) 
      {
        _db.Courses.Add(course);
        _db.SaveChanges();
      }  
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCourse = _db.Courses
        .Include(course => course.JoinEntitiesCS)
        .ThenInclude(join => join.Student)
        .FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    public ActionResult Edit(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost]
    public ActionResult Edit(Course course)
    {
      _db.Entry(course).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      _db.Courses.Remove(thisCourse);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddStudent(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      var thisCourseStudent = _db.CourseStudent.Where(thisStudent => thisStudent.CourseId == id);
      
      List<Student> students = _db.Students.ToList();
      List<Student> students2 = _db.Students.ToList();

      foreach (CourseStudent courseStudent in thisCourseStudent)
      {
        foreach(Student student in students)
        {
          if (student.StudentId == courseStudent.StudentId)
          {
            students2.Remove(student);
          }
        }
      } 
      ViewBag.StudentId = new SelectList(students2, "StudentId", "FirstName");
      return View(thisCourse);
    } 

    [HttpPost]
    public ActionResult AddStudent(Course course, int studentId)
    {
      if (studentId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { StudentId = studentId, CourseId = course.CourseId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
}