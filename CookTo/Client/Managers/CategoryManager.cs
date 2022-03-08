using CookTo.Shared.Features.ManageCategory;

namespace CookTo.Client.Managers;

public class CategoryManager : BaseManager<CategoryDto>
{
    public CategoryManager(IHttpClientFactory factory) : base(factory, "category")
    {
    }
}

