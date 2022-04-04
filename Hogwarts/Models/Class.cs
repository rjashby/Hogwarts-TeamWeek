using System.Collections.Generic;

namespace Hogwarts.Models;
{
  public class Class
    public Class()
    {
      this.JoinEntities = new HashSet<ClassStudent>();
    }
    public int ClassId { get; set; }

    public string ClassName { get; set; }

    public string ClassNumber { get; set; }

    public virtual ICollections<ClassStudent> JoinEntities { get; set; }
}