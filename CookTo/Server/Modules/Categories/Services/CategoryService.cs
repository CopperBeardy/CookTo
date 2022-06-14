using CookTo.Server.Modules;
using CookTo.Server.Modules.Categories.Core;

namespace CookTo.Server.Modules.Categories.Services;

public class CategoryService : BaseService<CategoryDocument>, ICategoryService
{
    public CategoryService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}
