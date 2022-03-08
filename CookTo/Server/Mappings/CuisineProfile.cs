using AutoMapper;
using CookTo.Server.Documents.CuisineDocument;
using CookTo.Shared.Features.ManageCuisine;

namespace CookTo.Server.Mappings;

public class CuisineProfile : Profile
{
    public CuisineProfile() { CreateMap<CuisineDto, Cuisine>().ReverseMap(); }
}
