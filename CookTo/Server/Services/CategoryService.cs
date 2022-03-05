using CookTo.Server.Documents.CategoryDocument;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class CategoryService : BaseService<Category>, ICategoryService
{
    public CategoryService(ICookToDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Seed()
    {
        var categories = new List<Category>()
        {
            new Category() { Name = "Cake" },
            new Category() { Name = "Baking" },
            new Category() { Name = "Main" },
            new Category() { Name = "Light Meal" },
            new Category() { Name = "Starter" },
            new Category() { Name = "Nibbles" },
            new Category() { Name = "Brunch" },
            new Category() { Name = "Side" },
            new Category() { Name = "Dessert" }
        };

        await dbCollection.InsertManyAsync(categories);
    }
}
