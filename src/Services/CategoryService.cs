using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace blazor_blog.Services;

public class CategoryService(BlogContext context) : ICategoryService
{
  private readonly BlogContext _context = context;
  public async Task<IEnumerable<Category>> GetCategories()
  {
    return await _context.Categories.AsNoTracking().ToListAsync();
  }

  public async Task<CreatedCategory> SaveCategory(Category model)
  {
    try
    {
      if (model.Id > 0)
      {
        _context.Categories.Update(model);
      }
      else
      {
        model.Slug = model.Slug.Slugify();
        await _context.Categories.AddAsync(model);
      }
    }
    catch (Exception ex)
    {
      return CreatedCategory.Failure(ex.Message);
    }
    await _context.SaveChangesAsync();
    return CreatedCategory.Success();
  }
}
