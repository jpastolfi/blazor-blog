using Microsoft.EntityFrameworkCore;

namespace blazor_blog.Services;

public class BlogPostService(BlogContext context) : IBlogPostService
{
  private readonly BlogContext _context = context;

  public async Task<BlogPostDTO?> GetPost(int blogPostId) => await _context.BlogPosts
    .Include(bp => bp.Category)
    .AsNoTracking()
    .Select(BlogPostDTO.Selector)
    .FirstOrDefaultAsync(bp => bp.Id == blogPostId);

  public async Task<IEnumerable<BlogPost>> GetPosts() =>
  await _context.BlogPosts
    .Include(bp => bp.Category)
    .AsNoTracking()
    .ToListAsync();

  public async Task<CreatedCategory> SavePost(BlogPostDTO post, int userId)
  {
    if (post.Id == 0)
    {
      var entity = post.ToBlogEntity(userId);
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
      BlogPost entity = await _context.BlogPosts.FirstOrDefaultAsync(bp => bp.Id == post.Id);
      // Does the post already exists?
      if (entity is not null)
      {
        // Has the post been published already?
        var alreadyBeenPublished = entity.IsPublished;
        // Merges the old post with the new one
        entity = post.Merge(entity);
        // Changes the modified date to now
        entity.ModifiedOn = DateTime.Now;

        if (entity.IsPublished)
        {
          // If you're in there, the blog post was set to publish on the edit
          if (alreadyBeenPublished)
          {
            // Nothing to do. The post had already been published before
          }
          else
          {
            // The blog post is now going to be published
            entity.PublishedOn = DateTime.Now;
          }
        }
        else if (alreadyBeenPublished)
        {
          // If you're in here, the blog post had already been published before the edit
          if (!entity.IsPublished)
          {
            // If you're in here, the post had been published before and now is going to be "unpublished"
            entity.PublishedOn = null;
          }
        }
      }
      else
      {
        return CreatedCategory.Failure("This blog post does not exist");
      }
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