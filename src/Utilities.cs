namespace blazor_blog;

public static class Utilities
{
  private static readonly string[] colorClasses = new string[] { "primary", "success", "info", "danger", "warning", "dark" };
  public static string GetRandomColorClass() => colorClasses.OrderBy(c => Guid.NewGuid()).First();
  public static string GetInitials(string text)
  {
    const string defaultInitials = "BB";
    if (!string.IsNullOrEmpty(text))
    {
      var parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
      if (parts.Length > 1)
      {
        return $"{parts[0][0]}{parts[1][0]}";
      }
      else
      {
        return text.Length > 1 ? text[..2] : text;
      }
    }
    return defaultInitials;
  }
}