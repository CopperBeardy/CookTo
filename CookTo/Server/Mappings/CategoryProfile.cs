using AutoMapper;
using CookTo.Server.Documents;
using CookTo.Shared.Features;
using CookTo.Shared.Models;

namespace CookTo.Server.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile() { CreateMap<Category, CategoryDocument>().ReverseMap(); }
}
