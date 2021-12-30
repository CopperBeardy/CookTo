using CookTo.Server.Services.Interfaces;
using MongoDB.Bson;

namespace CookTo.Server.Services;
public class RecipeService : BaseService<Recipe>, IRecipeService
{
	public RecipeService(ICookToDbContext dbContext) : base(dbContext)
	{
	}
}


