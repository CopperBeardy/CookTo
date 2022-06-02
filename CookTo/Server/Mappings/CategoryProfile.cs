using AutoMapper;
using CookTo.Server.Documents;
using CookTo.Shared.Features;

namespace CookTo.Server.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile() { CreateMap<CategoryDocument, CategoryDocument>().ReverseMap(); }
}
