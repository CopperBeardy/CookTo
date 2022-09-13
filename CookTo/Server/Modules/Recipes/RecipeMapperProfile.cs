using AutoMapper;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Shared.Modules.ManageTips;

namespace CookTo.Server.Modules.Recipes;

public class RecipeMapperProfile : Profile
{
	public RecipeMapperProfile()
	{
		CreateMap<Recipe, RecipeDocument>().ReverseMap();

		CreateMap<CookingStep, CookingStepDocument>().ReverseMap();
		CreateMap<ShoppingItem, ShoppingItemDocument>().ReverseMap();
		CreateMap<CookingStepIngredient, CookingStepIngredientDocument>().ReverseMap();
		CreateMap<UtensilPart, UtensilPartDocument>().ReverseMap();
		CreateMap<RecipePartIngredient, RecipePartIngredientDocument>().ReverseMap();
		CreateMap<RecipePart, RecipePartDocument>().ReverseMap();
		CreateMap<RecipeDocument, RecipeSummary>();

		CreateMap<RecipeDocument, HighlightedRecipe>();
	}
}
