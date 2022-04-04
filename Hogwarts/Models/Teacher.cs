using System.Collections.Generic;
using System;

namespace Hogwarts.Models 
{
  public class Teacher 
  {
    public Teacher ()
    {
      this.JoinEntitiesCT = new HashSet<CourseTeacher>();
    }
    public int TeacherId {get;set;}
    public string Name {get;set;}
    public string HeadshotPhotoURL {get;set;}
    public virtual ICollection<CourseTeacher> JoinEntitiesCT { get; }
  }
}