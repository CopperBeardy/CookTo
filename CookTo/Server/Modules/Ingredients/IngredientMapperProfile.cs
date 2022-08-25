using AutoMapper;
using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Ingredients;

public class IngredientMapperProfile : Profile
{
	public IngredientMapperProfile() { CreateMap<Ingredient, IngredientDocument>().ReverseMap(); }
}
