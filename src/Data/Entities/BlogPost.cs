using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace blazor_blog.Data.Entities;

public class BlogPost
{
  [Key]
  public int Id { get; set; }
  [Required, MaxLength(120)]
  public string Title { get; set; }
  [Required, MaxLength(150)]
  public string? Slug { get; set; }
  public int CategoryId { get; set; }
  [Required, MaxLength(300)]
  public string? Introduction { get; set; }
  [Required]
  public string? Content { get; set; }
  public DateTime CreatedOn { get; set; }
  public bool IsPublished { get; set; }
  public DateTime? PublishedOn { get; set; }
  public DateTime? ModifiedOn { get; set; }
  public virtual Category? Category { get; set; }
  public virtual User User { get; set; }
  [ForeignKey("UserId")]
  public int UserId { get; set; }
  [NotMapped]
  public string CategoryName => Category.Name;
}