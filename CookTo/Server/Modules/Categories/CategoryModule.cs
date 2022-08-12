using CookTo.Server.Modules.Categories.Handlers;
using CookTo.Server.Modules.Categories.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;


namespace CookTo.Server.Modules.Categories;

public class CategoryModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.CATEGORY);
        api.MapGet("/", async ([AsParameters] CommonParameters common) => await GetAllHandler.Handle(common));

        api.MapPost("/", async (Category category, [AsParameters] CommonParameters common) => await PostHandler.Handle(category, common))
            .RequireAuthorization();

        return api;
    }


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}
