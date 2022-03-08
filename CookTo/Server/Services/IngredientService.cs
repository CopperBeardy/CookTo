using CookTo.Server.Documents.IngredientDocument;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class IngredientService : BaseService<Ingredient>, IIngredientService
{
    public IngredientService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}