using CookTo.Shared.Models;

namespace CookTo.Client.Repositories;

public class IngredientRepository : BaseRepository<Ingredient>
{
	public IngredientRepository(HttpClient client) : base(client, nameof(Ingredient))
	{
	}
}
