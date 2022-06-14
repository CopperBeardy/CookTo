using AutoMapper;
using CookTo.Server.Modules.Utensils.Core;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server.Modules.Utensils.MapperProfile;

public class UtensilProfile : Profile
{
    public UtensilProfile() { CreateMap<Utensil, UtensilDocument>().ReverseMap(); }
}
