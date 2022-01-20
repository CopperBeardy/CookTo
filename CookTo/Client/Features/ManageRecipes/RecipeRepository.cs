namespace CookTo.Client.Features.ManageRecipes;

public class RecipeRepository : BaseRepository<Recipe>
{
	public RecipeRepository(HttpClient client) : base(client, nameof(Recipe))
	{
	}
}
