using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Server.Modules.Categories;

public partial class CategoryModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.CATEGORY);

        api.MapGet("/", GetAllCategories);
        api.MapPost("/", PostCategory).RequireAuthorization();

        return api;
    }

    internal static async Task<List<Category>> GetAllCategories(ICategoryService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);
        var categories = new List<Category>();

        if (entites is not null || entites.Any())
            categories.AddRange(entites.Select(c => new Category { Id = c.Id, Name = c.Name }));

        return categories;
    }

    internal static async Task<Category> PostCategory(Category category, ICategoryService service, CancellationToken cancellationToken)
    {
        var newCategory = new CategoryDocument() { Name = category.Name };
        await service.CreateAsync(newCategory, cancellationToken);

        return new Category { Id = newCategory.Id, Name = newCategory.Name };
    }


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}

