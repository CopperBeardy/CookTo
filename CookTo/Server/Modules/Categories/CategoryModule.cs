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

    internal static async Task<IResult> GetAllCategories(ICategoryService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);
        var response = new List<Category>();

        if (entites is not null || entites.Any())
            response.AddRange(entites.Select(c => new Category { Id = c.Id, Name = c.Name }));

        return TypedResults.Ok( response);
    }

    internal static async Task<IResult> PostCategory(Category category, ICategoryService service, CancellationToken cancellationToken)
    {
        var newCategory = new CategoryDocument() { Name = category.Name };
        await service.CreateAsync(newCategory, cancellationToken);
        var response = new Category { Id = newCategory.Id, Name = newCategory.Name };
        return  TypedResults.Ok(response);
    }


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}

