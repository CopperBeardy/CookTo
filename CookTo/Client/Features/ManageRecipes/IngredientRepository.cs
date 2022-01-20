
namespace CookTo.Client.Features.ManageRecipes;

public class IngredientRepository : BaseRepository<Ingredient>
{
	public IngredientRepository(HttpClient client) : base(client, nameof(Ingredient))
	{
	}
}
