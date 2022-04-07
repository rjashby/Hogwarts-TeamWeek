using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Hogwarts.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Hogwarts.Controllers
{
  public class HomeController : Controller
  {
    private readonly HogwartsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<HomeController> _logger;


    public HomeController(UserManager<ApplicationUser> userManager, HogwartsContext db, ILogger<HomeController> logger)
    {
      _userManager = userManager;
      _db = db;
      _logger = logger;
    }

    public IActionResult Index()
    {
      if (User.Identity.IsAuthenticated)
      {
        var id = _db.Students.FirstOrDefault(Student => Student.Email == User.Identity.Name).StudentId;
        ViewBag.ThisStudent = _db.Students
            .FirstOrDefault(s => s.StudentId == id);
      }
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
