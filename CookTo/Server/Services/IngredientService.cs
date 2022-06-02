using CookTo.Server.Documents;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class IngredientService : BaseService<IngredientDocument>, IIngredientService
{
    public IngredientService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}