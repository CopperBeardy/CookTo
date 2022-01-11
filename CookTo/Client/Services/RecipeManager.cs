using CookTo.Shared.Models;

namespace CookTo.Client.Services;

public class RecipeManager :APIManager<Recipe>
{
	public RecipeManager(HttpClient client):base(client,nameof(Recipe))
	{

	}
}
