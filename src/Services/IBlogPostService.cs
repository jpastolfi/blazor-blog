namespace blazor_blog.Services;

public interface IBlogPostService
{
  Task<IEnumerable<BlogPost>> GetPosts();
  Task<CreatedCategory> SavePost(BlogPostDTO post, int userId);
}