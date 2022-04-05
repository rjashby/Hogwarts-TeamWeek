using System.ComponentModel.DataAnnotations;

namespace Hogwarts.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    [Display(Name = "Title")]
    public string Title { get; set; }

    [Required]
    [Display(Name = "Student ID")]
    public int StudentId { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Year")]
    public int Year { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
  }
}
