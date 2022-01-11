using CookTo.Shared.Models;

namespace CookTo.Client.Services;

public class IngredientManager : APIManager<Ingredient>
{
	public IngredientManager(HttpClient client) :base(client,nameof(Ingredient))
	{

	}
}
