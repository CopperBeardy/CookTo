using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Server.Modules.Categories.Handlers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;


namespace CookTo.Server.Modules.Categories;

public class CategoryModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.CATEGORY);
        api.MapGet("/", async (ICategoryService service, CancellationToken cancellationToken) =>
        {
            var response = await GetAll.Handle(service, cancellationToken);
            return Results.Ok(response);
        });

        api.MapPost("/", async (Category category, ICategoryService service, CancellationToken cancellationToken) =>
        {
            await Post.Handle(category, service, cancellationToken);
        })
            .RequireAuthorization();

        return api;
    }


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}
