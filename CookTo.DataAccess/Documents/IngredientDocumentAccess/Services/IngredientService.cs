
using CookTo.DataAccess.DbContext;

namespace CookTo.DataAccess.Documents.IngredientDocumentAccess.Services;

public class IngredientService : BaseService<IngredientDocument>, IIngredientService
{
    public IngredientService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}