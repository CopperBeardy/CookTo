using CookTo.Server.Documents;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class CategoryService : BaseService<CategoryDocument>, ICategoryService
{
    public CategoryService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}
