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
      LoggedInUser = new(userId, displayName!);
    }
  }
  public LoggedInUser LoggedInUser { get; private set; } = new(0, string.Empty);
  public override async Task<AuthenticationState> GetAuthenticationStateAsync()
  {
    var claimsPrincipal = new ClaimsPrincipal();
    try
    {
      var user = await _authService.GetUserFromStorage();
      if (user is not null)
      {
        claimsPrincipal = GetClaimsPrincipalFromUser(user.Value);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine("O erro foi: " + ex.Message);
    }
    var authState = new AuthenticationState(claimsPrincipal);
    NotifyAuthenticationStateChanged(Task.FromResult(authState));
    return authState;
  }
  public async Task<string?> LoginAsync(LoginModel model)
  {
    var loggedInUser = await _authService.LoginUserAsync(model);
    if (loggedInUser is null)
    {
      return "Invalid credentials";
    }
    var authState = new AuthenticationState(GetClaimsPrincipalFromUser(loggedInUser.Value));
    NotifyAuthenticationStateChanged(Task.FromResult(authState));
    return null;
  }
  public async Task LogoutAsync()
  {
    await _authService.RemoveUserFromStorage();
    var authState = new AuthenticationState(new ClaimsPrincipal());
    NotifyAuthenticationStateChanged(Task.FromResult(authState));
  }
  private static ClaimsPrincipal GetClaimsPrincipalFromUser(LoggedInUser user)
  {
    var identity = new ClaimsIdentity(
            new[]
            {
          new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
          new Claim(ClaimTypes.Name, user.DisplayName)
            }, BlogAuthType);
    return new ClaimsPrincipal(identity);
  }
  public void Dispose() => AuthenticationStateChanged -= BlogAuthStateProvider_AuthenticationStateChanged;
}