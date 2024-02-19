using System.ComponentModel.DataAnnotations;

namespace blazor_blog.Models;

public class LoginModel
{
  [Required, EmailAddress, DataType(DataType.EmailAddress)]
  public string Username { get; set; }
  [Required, MinLength(5)]
  public string Password { get; set; }

}

public record struct LoggedInUser(int UserId, string DisplayName)
{
  public readonly bool IsEmpty => UserId == 0;
};
