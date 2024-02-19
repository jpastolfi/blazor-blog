using System.Text.Json;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace blazor_blog.Auth;

public class AuthService
{
  private readonly UserService _userService;
  private readonly ProtectedLocalStorage _protectedLocalStorage;
  private const string UserStorageKey = "blog_user";
  private readonly JsonSerializerOptions _jsonSerializerOptions = new();
  public AuthService(UserService userService, ProtectedLocalStorage protectedLocalStorage)
  {
    _userService = userService;
    _protectedLocalStorage = protectedLocalStorage;
  }
  public async Task<LoggedInUser?> LoginUserAsync(LoginModel model)
  {
    var loggedInUser = await _userService.LoginAsync(model);
    if (loggedInUser is not null)
    {
      await SaveUserToStorage(loggedInUser.Value);
    }
    return loggedInUser;
  }
  public async Task SaveUserToStorage(LoggedInUser user)
  {
    await _protectedLocalStorage.SetAsync(UserStorageKey, JsonSerializer.Serialize(user, _jsonSerializerOptions));
  }
  public async Task<LoggedInUser?> GetUserFromStorage()
  {
    try
    {
      var result = await _protectedLocalStorage.GetAsync<string>(UserStorageKey);
      if (result.Success && !string.IsNullOrWhiteSpace(result.Value))
      {
        var loggedInUser = JsonSerializer.Deserialize<LoggedInUser>(result.Value, _jsonSerializerOptions);
        return loggedInUser;
      }
    }
    catch (InvalidOperationException)
    {
      throw;
    }
    return null;
  }
  public async Task RemoveUserFromStorage()
  {
    await _protectedLocalStorage.DeleteAsync(UserStorageKey);
  }
}