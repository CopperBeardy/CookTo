using AutoMapper;
using CookTo.Server.Documents;
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Server.Mappings;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<FullRecipe, RecipeDocument>().ReverseMap();
        CreateMap<CookingStep, CookingStepDocument>().ReverseMap();
        CreateMap<RecipePart, RecipePartDocument>().ReverseMap();
        CreateMap<UtensilPart, UtensilPartDocument>().ReverseMap();
        CreateMap<PartIngredient, PartIngredientDocument>().ReverseMap();
        CreateMap<RecipeDocument, HighlightedRecipe>();
    }
}
