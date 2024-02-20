namespace blazor_blog.Services;


public interface IUserService
{
  Task<LoggedInUser?> LoginAsync(LoginModel model);
}