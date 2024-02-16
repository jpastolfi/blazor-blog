using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace blazor_blog.Auth;

public class BlogAuthStateProvider : AuthenticationStateProvider, IDisposable
{
  private const string BlogAuthType = "blog_auth";
  private readonly AuthService _authService;
  public BlogAuthStateProvider(AuthService authService)
  {
    _authService = authService;
    AuthenticationStateChanged += BlogAuthStateProvider_AuthenticationStateChanged;
  }
  private async void BlogAuthStateProvider_AuthenticationStateChanged(Task<AuthenticationState> task)
  {
    var authState = await task;
    if (authState is not null)
    {
      var userId = Convert.ToInt32(authState.User.FindFirstValue(ClaimTypes.NameIdentifier));
      var displayName = authState.User.FindFirstValue(ClaimTypes.Name);
      LoggedInUser = new LoggedInUser(userId, displayName!);
    }
  }
  public LoggedInUser LoggedInUser { get; private set; } = new(0, string.Empty);
  public override async Task<AuthenticationState> GetAuthenticationStateAsync()
  {
    var claimsPrincipal = new ClaimsPrincipal();
    var user = await _authService.GetUserFromStorage();
    if (user is not null)
    {
      var identity = new ClaimsIdentity(
        new[]
        {
          new Claim(ClaimTypes.NameIdentifier, user.Value.UserId.ToString()),
          new Claim(ClaimTypes.NameIdentifier, user.Value.DisplayName)
        }, BlogAuthType);
      claimsPrincipal = new(identity);
    }
    return new AuthenticationState(claimsPrincipal);
  }
  public void Dispose() => AuthenticationStateChanged -= BlogAuthStateProvider_AuthenticationStateChanged;
}