using CookTo.Server.Documents.IngredientDocument;
using CookTo.Shared.Features.ManageIngredients.Shared;

namespace CookTo.Server.Mappings;

public static class IngredientMapping
{
    public static Ingredient FromDtoToIngredient(IngredientDto obj) => new Ingredient() { Id = obj.Id, Name = obj.Name };

    public static IngredientDto FromIngredientToDto(Ingredient obj) => new IngredientDto()
    {
        Id = obj.Id,
        Name = obj.Name
    };
}
