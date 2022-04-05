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

      public ActionResult Details(int id)
      {
          var thisTeacher = _db.Teachers
            .Include(s => s.JoinEntitiesCT)
            .ThenInclude(j => j.Course)
            .FirstOrDefault(s => s.TeacherId == id);
          return View(thisTeacher);
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

      public ActionResult Delete(int id)
      {
        var thisTeacher = _db.Teachers.FirstOrDefault(teacher => teacher.TeacherId == id);
        return View(thisTeacher);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        var thisTeacher = _db.Teachers.FirstOrDefault(teacher => teacher.TeacherId == id);
        _db.Teachers.Remove(thisTeacher);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult AddCourse(int id)
      {
        var thisTeacher = _db.Teachers.FirstOrDefault(teacher => teacher.TeacherId == id);
        var thisCourseTeacher = _db.CourseTeacher.Where(courseStudent => courseStudent.TeacherId == id);
        
        List<Course> courses = _db.Courses.ToList();
        List<Course> courses2 = _db.Courses.ToList();

        foreach (CourseTeacher courseTeacher in thisCourseTeacher)
        {
          foreach(Course course in courses)
          {
            if (course.CourseId == courseTeacher.CourseId)
            {
              courses2.Remove(course);
            }
          }
        } 
        ViewBag.CourseId = new SelectList(courses2, "CourseId", "CourseName");
        return View(thisTeacher);
      } 

      [HttpPost]
      public ActionResult AddCourse(Teacher teacher, int CourseId)
      {
        if (CourseId != 0)
        {
          _db.CourseTeacher.Add(new CourseTeacher() { TeacherId = teacher.TeacherId, CourseId = CourseId });
          _db.SaveChanges();
        }
        return RedirectToAction("Index");
      }
    }
}