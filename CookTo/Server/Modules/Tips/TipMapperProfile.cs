using AutoMapper;
using CookTo.DataAccess.Documents.TipDocumentAccess;
using CookTo.Shared.Modules.ManageTips;

namespace CookTo.Server.Modules.Tips;

public class TipMapperProfile : Profile
{
	public TipMapperProfile() { CreateMap<Tip, TipDocument>().ReverseMap(); }
}
