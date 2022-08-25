using AutoMapper;
using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Cuisines;

public class CuisineMapperProfile : Profile
{
	public CuisineMapperProfile() { CreateMap<Cuisine, CuisineDocument>().ReverseMap(); }
}
