using System.Collections.Generic;

namespace Hogwarts.Models
{
  public class Student 
  {
    public Student()
    {
      this.JoinEntitiesCS = new HashSet<CourseStudent>();
    }
    public int StudentId {get; set;}
    public string Name {get; set;}
    public string House {get; set;}
    public int Year {get; set;}
    public string Wand {get; set;}
    public virtual ICollection<CourseStudent> JoinEntitiesCS {get; set;}
  }
}