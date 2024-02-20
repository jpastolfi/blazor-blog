namespace blazor_blog.Models
{
  public record struct CreatedCategory(bool Status, string? ErrorMessage = null)
  {
    public static CreatedCategory Success() => new(true);
    public static CreatedCategory Failure(string errorMessage) => new(false, errorMessage);
  }
}