using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Client.HTTPManagers;

public class CategoryManager : BaseManager<Category>
{
    public CategoryManager(IHttpClientFactory factory) : base(factory, EndpointTemplate.CATEGORY)
    {
    }
}

