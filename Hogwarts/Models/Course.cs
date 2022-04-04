using System.Collections.Generic;

namespace Hogwarts.Models
{
  public class Course
  {
    public Course()
    {
      this.JoinEntitiesCS = new HashSet<CourseStudent>();
    }

    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string CourseNum { get; set; }
    public virtual ICollection<CourseStudent> JoinEntitiesCS { get; set; }
  }

}