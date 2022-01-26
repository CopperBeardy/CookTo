using AutoMapper;
using CookTo.Server.Documents.RecipeDocument;
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Server.MappingProfiles;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        var configuration = new MapperConfiguration(
            cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Recipe, AddRecipeDto>().ReverseMap();
                cfg.CreateMap<Recipe, RecipeResultDto>().ReverseMap();
            });
    }
}
