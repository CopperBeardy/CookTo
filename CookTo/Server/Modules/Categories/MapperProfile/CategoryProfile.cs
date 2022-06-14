using AutoMapper;
using CookTo.Server.Modules.Categories.Core;

using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Server.Modules.Categories.MapperProfile;

public class CategoryProfile : Profile
{
    public CategoryProfile() { CreateMap<Category, CategoryDocument>().ReverseMap(); }
}
