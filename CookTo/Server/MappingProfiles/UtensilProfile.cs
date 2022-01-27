using AutoMapper;
using CookTo.Server.Documents.UtensilDocument;
using CookTo.Shared.Features.ManageUtensils;

namespace CookTo.Server.MappingProfiles;

public class UtensilProfile : Profile
{
    public UtensilProfile()
    {
        CreateMap<Utensil, AddUtensilDto>().ReverseMap();
        CreateMap<Utensil, UtensilResultDto>().ReverseMap();
        CreateMap<List<Utensil>, List<UtensilResultDto>>().ReverseMap();
    }
}
