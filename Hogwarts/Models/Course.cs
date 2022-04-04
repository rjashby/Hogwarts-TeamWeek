using System.Collections.Generic;

namespace Hogwarts.Models
{
  public class Course
  {
    public Course()
    {
      this.JoinEntities = new HashSet<CourseStudent>();
    }

    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string CourseNum { get; set; }
    public virtual ICollection<CourseStudent> JoinEntities { get; set; }
  }

}