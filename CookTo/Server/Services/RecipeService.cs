using CookTo.Server.Documents.RecipeDocument;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class RecipeService : BaseService<Recipe>, IRecipeService
{
    public RecipeService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}


