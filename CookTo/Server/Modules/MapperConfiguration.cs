using AutoMapper;
using CookTo.Server.Modules.Categories;
using CookTo.Server.Modules.Cuisines;
using CookTo.Server.Modules.Ingredients;
using CookTo.Server.Modules.Recipes;
using CookTo.Server.Modules.Tips;
using CookTo.Server.Modules.Utensils;

namespace CookTo.Server.Modules;

public  static class MapperConfigurate
{
    public static IMapper Configure()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AllowNullCollections = true;
            cfg.AllowNullDestinationValues = true;
            cfg.AddProfile(new CategoryMapperProfile());
            cfg.AddProfile(new CuisineMapperProfile());
            cfg.AddProfile(new IngredientMapperProfile());
            cfg.AddProfile(new TipMapperProfile());
            cfg.AddProfile(new UtensilMapperProfile());
            cfg.AddProfile(new RecipeMapperProfile());
        });

        var mapper = config.CreateMapper();
        return mapper;
    }
}
