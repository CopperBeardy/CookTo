using AutoMapper;
using CookTo.Server.Documents.UtensilDocument;
using CookTo.Shared.Features.ManageUtensils;

namespace CookTo.Server.Mappings;

public class UtensilProfile : Profile
{
    public UtensilProfile() { CreateMap<UtensilDto, Utensil>().ReverseMap(); }
}
