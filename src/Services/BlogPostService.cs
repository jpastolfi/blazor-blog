using Microsoft.EntityFrameworkCore;

namespace blazor_blog.Services;

public class BlogPostService(BlogContext context) : IBlogPostService
{
  private readonly BlogContext _context = context;

  public async Task<IEnumerable<BlogPost>> GetPosts() => await _context.BlogPosts.AsNoTracking().ToListAsync();
}