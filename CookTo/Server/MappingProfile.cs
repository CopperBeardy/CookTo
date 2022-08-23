using AutoMapper;
using CookTo.DataAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.DataAccess.Documents.TipDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Shared.Modules.ManageTips;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Ingredient, IngredientDocument>().ReverseMap();
        CreateMap<Category, CategoryDocument>().ForMember(dest => dest.Id, src => src.Ignore());
        CreateMap<CategoryDocument, Category>();
        CreateMap<Tip, TipDocument>().ReverseMap();
        CreateMap<Utensil, UtensilDocument>().ReverseMap();
        CreateMap<Cuisine, CuisineDocument>().ReverseMap();

        CreateMap<Recipe, RecipeDocument>()
            .ForMember(dest => dest.Dietaries, opt => opt.AllowNull())
            .ForMember(dest => dest.Tips, opt => opt.AllowNull())
            .ReverseMap();
        CreateMap<CookingStep, CookingStepDocument>()
            .ForMember(dest => dest.StepIngredients, src => src.AllowNull())
            .ReverseMap();
        CreateMap<ShoppingItem, ShoppingItemDocument>()
            .ForMember(dest => dest.Quantity, src => src.AllowNull())
            .ForMember(dest => dest.Measure, src => src.AllowNull())
            .ForMember(dest => dest.AdditionalInformation, src => src.AllowNull())
            .ReverseMap();

        CreateMap<StepIngredient, StepIngredientDocument>()
            .ForMember(dest => dest.Quantity, src => src.AllowNull())
            .ForMember(dest => dest.Measure, src => src.AllowNull())
            .ReverseMap();
        CreateMap<UtensilPart, UtensilPartDocument>().ReverseMap();

        CreateMap<RecipeDocument, RecipeSummary>();

        CreateMap<RecipeDocument, HighlightedRecipe>();
    }
}
