using AutoMapper;
using CookTo.Server.Documents;
using CookTo.Shared.Features;
using CookTo.Shared.Models;

namespace CookTo.Server.Mappings;

public class UtensilProfile : Profile
{
    public UtensilProfile() { CreateMap<Utensil, UtensilDocument>().ReverseMap(); }
}
