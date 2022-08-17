
using CookTo.DataAccess.DbContext;

namespace CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;

public class CategoryService : BaseService<CategoryDocument>, ICategoryService
{
    public CategoryService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}
