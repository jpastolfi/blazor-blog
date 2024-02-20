using blazor_blog.Data;
using blazor_blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blazor_blog.Services;

public class UserService : IUserService
{
  private readonly BlogContext _context;
  public UserService(BlogContext context)
  {
    _context = context;
  }
  public async Task<LoggedInUser?> LoginAsync(LoginModel model)
  {
    var dbUser = await _context.Users
                  .AsNoTracking()
                  .FirstOrDefaultAsync(u => u.Email == model.Username);
    if (dbUser is not null)
    {
      // Login Success
      return new LoggedInUser(dbUser.UserId, $"{dbUser.FirstName} {dbUser.LastName}".Trim());
    }
    else
    {
      // Login fail
      return null;
    }
  }
}