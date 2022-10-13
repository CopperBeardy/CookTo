using CookTo.Shared;
using CookTo.Shared.Models.ManageCategories;

namespace CookTo.Client.Services;

public class CategoryManager : APIRepository<Category>
{
    public CategoryManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory, ControllerNames.CATEGORY)
    {
    }
}
