using CookTo.Shared.Features;
using CookTo.Shared.Models;

namespace CookTo.Client.Managers;

public class CategoryManager : BaseManager<Category>
{
    public CategoryManager(IHttpClientFactory factory) : base(factory, "category")
    {
    }
}

