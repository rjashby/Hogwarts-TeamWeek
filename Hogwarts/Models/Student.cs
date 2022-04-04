using S

namespace Hogwarts 
{
  public class Student 
  {
    
    public int StudentId {get; set;}
    public string Name {get; set;}
    public string House {get; set;}
    public int Year {get; set;}
    public string Wand {get; set;}
    public virtual IEnumerable Class {get; set;}
    // public virtual ApplicationUser User { get; set; }

  }
}