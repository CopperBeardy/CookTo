using AutoMapper;
using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server.Modules.Utensils;

public class UtensilMapperProfile : Profile
{
	public UtensilMapperProfile() { CreateMap<Utensil, UtensilDocument>().ReverseMap(); }
}
