using System.ComponentModel.DataAnnotations;

namespace blazor_blog.Data.Entities;
public class User
{
  [Key]
  public int UserId { get; set; }
  [Required, MaxLength(25)]
  public string? FirstName { get; set; }
  [MaxLength(25)]
  public string? LastName { get; set; }
  [Required, MaxLength(100)]
  public string? Email { get; set; }
  [Required, MaxLength(30)]
  public string? Salt { get; set; }
  [Required, MaxLength(100)]
  public string? Hash { get; set; }

}