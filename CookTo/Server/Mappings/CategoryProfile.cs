using AutoMapper;
using CookTo.Server.Documents.CategoryDocument;
using CookTo.Shared.Features.ManageCategory;

namespace CookTo.Server.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile() { CreateMap<CategoryDto, Category>().ReverseMap(); }
}
