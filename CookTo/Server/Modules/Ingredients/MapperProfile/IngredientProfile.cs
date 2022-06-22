using AutoMapper;
using CookTo.Server.Modules.Ingredients.Core;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Ingredients.MapperProfile;

public class IngredientProfile : Profile
{
    public IngredientProfile() { CreateMap<Ingredient, IngredientDocument>().ReverseMap(); }
}
