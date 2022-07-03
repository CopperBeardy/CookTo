using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Client.HttpManagers;

public class CategoryManager : BaseManager<Category>
{
    public CategoryManager(IHttpClientFactory factory) : base(factory, "category")
    {
    }
}

