using CookTo.Server.Documents.IngredientDocument;

namespace CookTo.Server.Services.Interfaces;

public interface IIngredientService : IBaseService<Ingredient>
{
    Task Seed();
}


