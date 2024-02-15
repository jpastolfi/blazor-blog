using blazor_blog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace blazor_blog.Data;

public class BlogContext : DbContext
{
  public BlogContext(DbContextOptions<BlogContext> options) : base(options)
  { }
  public DbSet<Category> Categories { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<BlogPost> BlogPosts { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      var connectionString = "Server=localhost;Database=blazor-blog;User=SA;Password=BlazingBlog1234!;TrustServerCertificate=True";
      optionsBuilder.UseSqlServer(connectionString);
    }
    /* base.OnConfiguring(optionsBuilder); */
#if DEBUG
    optionsBuilder.LogTo(Console.WriteLine);
#endif
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<User>()
      .HasData(
        new User
        {
          UserId = 1,
          Email = "visitor@blog.com",
          FirstName = "You are",
          LastName = "Hired",
          Salt = "text",
          Hash = "Banana"
        }
      );
  }
}