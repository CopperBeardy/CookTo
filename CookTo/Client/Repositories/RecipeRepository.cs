using CookTo.Shared.Models;

namespace CookTo.Client.Repositories;

public class RecipeRepository : BaseRepository<Recipe>
{
	public RecipeRepository(HttpClient client) : base(client, nameof(Recipe))
	{
	}
}
