using Microsoft.EntityFrameworkCore;

namespace blazor_blog.Services;

public class BlogPostService(BlogContext context) : IBlogPostService
{
  private readonly BlogContext _context = context;

  public async Task<IEnumerable<BlogPost>> GetPosts() => await _context.BlogPosts.AsNoTracking().ToListAsync();

  public async Task<CreatedCategory> SavePost(BlogPostDTO post, int userId)
  {
    var entity = post.ToBlogEntity(userId);
    if (entity.Id == 0)
    {
      entity.Slug = entity.Slug.Slugify();
      entity.CreatedOn = DateTime.Now;
      if (entity.IsPublished)
      {
        entity.PublishedOn = DateTime.Now;
      }
      await _context.AddAsync(entity);
    }
    else
    {

    }
    try
    {
      if (await _context.SaveChangesAsync() > 0)
      {
        return CreatedCategory.Success();
      }
      else
      {
        return CreatedCategory.Failure("Unknown error while saving");
      }
    }
    catch (Exception ex)
    {
      return CreatedCategory.Failure(ex.Message);
    }
  }
}