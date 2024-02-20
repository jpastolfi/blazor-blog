using System.Text.RegularExpressions;

namespace blazor_blog.Extensions;
public static class StringExtensions
{
  // Replaces any character that is not in the allowed set with an underscore
  public static string Slugify(string name) => Regex.Replace(name.ToLower(), @"[^a-zA-Z0-9\-\_]", "_", RegexOptions.Compiled, TimeSpan.FromSeconds(1)).Replace("--", "-").Trim();
}