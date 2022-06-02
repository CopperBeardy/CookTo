using AutoMapper;
using CookTo.Server.Documents;
using CookTo.Shared.Models;

namespace CookTo.Server.Mappings;

public class IngredientProfile : Profile
{
    public IngredientProfile() { CreateMap<Ingredient, IngredientDocument>().ReverseMap(); }
}
