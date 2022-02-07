using AutoMapper;
using CookTo.Server.Documents.IngredientDocument;
using CookTo.Shared.Features.ManageIngredients.Shared;

namespace CookTo.Server.Mappings;

public class IngredientProfile : Profile
{
    public IngredientProfile() { CreateMap<IngredientDto, Ingredient>().ReverseMap(); }
}
