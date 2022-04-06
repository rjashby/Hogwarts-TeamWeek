using System.Collections.Generic;

namespace Hogwarts.Models
{
  public class Student
  {
    public Student()
    {
      this.JoinEntitiesCS = new HashSet<CourseStudent>();
    }
    public int StudentId { get; set; }
    public string Email { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string House { get; set; }
    public int Year { get; set; }
    public string Wand { get; set; }
    public string WandURL { get; set; }
    public string Animal { get; set; }
    public string Robes { get; set; }

    public string Books { get; set; }
    public string Cauldron { get; set; }
    public string Tools { get; set; }
    public string Scale { get; set; }
    public string Phials { get; set; }
    public virtual ICollection<CourseStudent> JoinEntitiesCS { get; set; }
  }
}
