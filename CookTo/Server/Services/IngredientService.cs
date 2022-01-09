using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;
public class IngredientService : BaseService<Ingredient>, IIngredientService
{
	public IngredientService(ICookToDbContext dbContext) : base(dbContext)
	{ }

	public async Task<Ingredient> GetByNameAsync(string name) =>
	await dbCollection.Find(e => e.Name.Equals(name)).FirstOrDefaultAsync();

}