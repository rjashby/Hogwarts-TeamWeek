using System.Collections.Generic;
using System;

namespace Hogwarts.Models
{
  public class Teacher
  {
    // public Teacher ()
    // {
    //   this.JoinEntitiesCT = new HashSet<CourseTeacher>();
    // }
    public int TeacherId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string House { get; set; }
    public string CourseName { get; set; }
    public string CourseId { get; set; }
    public string HeadshotPhotoURL { get; set; }
    // public virtual ApplicationUser User {get; set;}
    // public virtual ICollection<CourseTeacher> JoinEntitiesCT { get; }
  }
}
