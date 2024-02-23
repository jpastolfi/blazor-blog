using blazor_blog.Data.Entities;
using Microsoft.AspNetCore.Mvc;
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
      var server = Environment.GetEnvironmentVariable("DBSERVER") ?? "localhost";
      var password = Environment.GetEnvironmentVariable("DBPASSWORD");
      var database = Environment.GetEnvironmentVariable("DBHOST");
      var connectionString = $"Server={server};Database={database};User=SA;Password={password};TrustServerCertificate=True";
      optionsBuilder.UseSqlServer(connectionString);
    }
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
          FirstName = "Tech",
          LastName = "Lead",
          Salt = "text",
          Hash = "Banana"
        }
      );
    /* modelBuilder.Entity<Category>()
      .HasData(
        new Category { },
        new Category { },
        new Category { },
        new Category { },
        new Category { },
        new Category { },
        new Category { },
        new Category { },
        new Category { },
        new Category { }
      ); */
  }
}