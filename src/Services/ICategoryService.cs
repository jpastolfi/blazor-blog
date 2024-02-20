namespace blazor_blog.Services;

public interface ICategoryService
{
  Task<IEnumerable<Category>> GetCategories();
  Task<CreatedCategory> SaveCategory(Category model);
}