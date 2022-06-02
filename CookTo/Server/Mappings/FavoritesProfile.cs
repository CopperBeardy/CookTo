using AutoMapper;
using CookTo.Server.Documents;
using CookTo.Shared.Features.ManageFavorites;

namespace CookTo.Server.Mappings;

public class FavoritesProfile : Profile
{
    public FavoritesProfile() { CreateMap<FavoritesDto, FavoriteRecipeDocument>().ReverseMap(); }
}
