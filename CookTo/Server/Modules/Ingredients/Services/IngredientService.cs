using CookTo.Server.Modules.Ingredients.Core;

namespace CookTo.Server.Modules.Ingredients.Services;

public class IngredientService : BaseService<IngredientDocument>, IIngredientService
{
    public IngredientService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}