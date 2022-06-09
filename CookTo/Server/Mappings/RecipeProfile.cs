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
        CreateMap<UtensilPart, UtensilPartDocument>().ReverseMap();
        CreateMap<StepIngredient, StepIngredientDocument>().ReverseMap();
        CreateMap<RecipeDocument, HighlightedRecipe>();
    }
}
