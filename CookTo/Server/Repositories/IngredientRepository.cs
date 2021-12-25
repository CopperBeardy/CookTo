using CookTo.Server.DbContext;
using CookTo.Shared.Models;


namespace CookTo.Server.Repositories;
public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
{
	public IngredientRepository(ICookToDbContext dbContext) : base(dbContext)
	{
	}
}