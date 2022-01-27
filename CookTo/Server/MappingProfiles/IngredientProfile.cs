using AutoMapper;
using CookTo.Server.Documents.IngredientDocument;
using CookTo.Shared.Features.ManageIngredients;

namespace CookTo.Server.MappingProfiles;

public class IngredientProfile : Profile
{
    public IngredientProfile()
    {
        CreateMap<Ingredient, IngredientResultDto>().ReverseMap();
        CreateMap<Ingredient, AddIngredientDto>().ReverseMap();
        CreateMap<List<Ingredient>, List<IngredientResultDto>>().ReverseMap();
    }
}
