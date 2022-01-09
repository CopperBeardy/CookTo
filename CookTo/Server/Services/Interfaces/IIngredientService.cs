namespace CookTo.Server.Services.Interfaces;
public interface IIngredientService : IBaseService<Ingredient>
{
	Task<Ingredient> GetByNameAsync(string name);
}


