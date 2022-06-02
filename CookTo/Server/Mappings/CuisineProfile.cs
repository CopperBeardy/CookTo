using AutoMapper;
using CookTo.Server.Documents;
using CookTo.Shared.Features;
using CookTo.Shared.Models;

namespace CookTo.Server.Mappings;

public class CuisineProfile : Profile
{
    public CuisineProfile() { CreateMap<CuisineDocument, CuisineDocument>().ReverseMap(); }
}
