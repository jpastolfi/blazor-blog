namespace blazor_blog.Services;

public interface IBlogPostService
{
  Task<IEnumerable<BlogPost>> GetPosts(bool IsPublished, string CategorySlug);
  Task<BlogPostDTO?> GetPost(int blogPostId);
  Task<CreatedCategory> SavePost(BlogPostDTO post, int userId);
  Task<BlogPost> GetPostBySlug(string slug, int id);
}