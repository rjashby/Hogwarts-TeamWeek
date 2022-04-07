using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Models
{
  public class HogwartsContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Student> Students {get; set;}
    public DbSet<Teacher> Teachers {get; set;}
    public HogwartsContext(DbContextOptions options) : base(options) {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}