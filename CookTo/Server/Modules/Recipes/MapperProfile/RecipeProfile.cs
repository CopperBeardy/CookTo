using AutoMapper;
using CookTo.Server.Modules.Recipes.Core;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Recipes.MapperProfile;

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
