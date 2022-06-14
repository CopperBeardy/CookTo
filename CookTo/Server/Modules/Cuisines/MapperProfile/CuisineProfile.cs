using AutoMapper;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Cuisines.MapperProfile;

public class CuisineProfile : Profile
{
    public CuisineProfile() { CreateMap<Cuisine, CuisineDocument>().ReverseMap(); }
}
