using AutoMapper;
using CookTo.Server.Documents.RecipeDocument;
using CookTo.Shared.Features.ManageRecipes.Shared;

namespace CookTo.Server.Mappings;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<RecipeDto, Recipe>().ReverseMap();
        CreateMap<CookingStep, SectionCookingStep>().ReverseMap();
        CreateMap<RecipePart, SectionRecipePart>().ReverseMap();
        CreateMap<UtensilPart, SectionUtensilPart>().ReverseMap();
        CreateMap<PartIngredient, SectionPartIngredient>().ReverseMap();
    }
}
