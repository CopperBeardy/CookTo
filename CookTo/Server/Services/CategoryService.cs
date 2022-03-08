using CookTo.Server.Documents.CategoryDocument;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class CategoryService : BaseService<Category>, ICategoryService
{
    public CategoryService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}
