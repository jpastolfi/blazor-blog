using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace blazor_blog.Data.Entities;

public class Category
{
  [Key]
  public int Id { get; set; }
  [Required, MaxLength(100)]
  public string? Name { get; set; }
  [Required, MaxLength(125)]
  public string? Slug { get; set; }
  public Category Clone() => (Category)this.MemberwiseClone();
}