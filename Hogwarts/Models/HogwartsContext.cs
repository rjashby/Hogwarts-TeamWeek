using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Models
{
  public class HogwartsContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Course> Courses {get; set;}
    public DbSet<Student> Students {get; set;}
    public DbSet<CourseStudent> CourseStudent {get; set;}
    public DbSet<CourseTeacher> Course {get;set;}
    public HogwartsContext(DbContextOptions options) : base(options) {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Teacher>()
          .HasData(
            new Teacher {TeacherId = 1, Name = "Minerva McGonagall", HeadshotPhotoURL = "~/img/teachers/headshot-mcgonagall.gif"},
            new Teacher {TeacherId = 2, Name = "Pomona Sprout", HeadshotPhotoURL = "~/img/teachers/headshot-sprout.gif"},
            new Teacher {TeacherId = 3, Name = "Severus Snape", HeadshotPhotoURL = "~/img/teachers/headshot-snape.gif"},
            new Teacher {TeacherId = 4, Name = "Horace Slughorn", HeadshotPhotoURL = "~/img/teachers/headshot-slughorn.gif"}
          );
    }
          

  }
}