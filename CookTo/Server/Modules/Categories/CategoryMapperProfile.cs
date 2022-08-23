using AutoMapper;
using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Server.Modules.Categories;

public class CategoryMapperProfile : Profile
{
    public CategoryMapperProfile()
    {
        CreateMap<Category, CategoryDocument>().ForMember(dest => dest.Id, src => src.Ignore());

        CreateMap<CategoryDocument, Category>();
    }
}
