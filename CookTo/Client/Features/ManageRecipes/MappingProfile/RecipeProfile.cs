using AutoMapper;
using CookTo.Client.Features.ManageRecipes.ViewModel;
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Client.Features.ManageRecipes.MappingProfile;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<RecipeDto, Recipe>().ReverseMap();
        CreateMap<Shared.Features.ManageRecipes.CookingStep, ViewModel.CookingStep>().ReverseMap();
        CreateMap<Shared.Features.ManageRecipes.RecipePart, ViewModel.RecipePart>().ReverseMap();
        CreateMap<Shared.Features.ManageRecipes.UtensilPart, ViewModel.UtensilPart>().ReverseMap();
        CreateMap<Shared.Features.ManageRecipes.PartIngredient, ViewModel.PartIngredient>().ReverseMap();
    }
}
