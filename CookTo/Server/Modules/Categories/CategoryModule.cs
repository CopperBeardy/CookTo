using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Categories.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Server.Modules.Categories;

public class CategoryModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/category");
        api.MapGet(
            "/",
            async (ICategoryService service, CancellationToken token) =>
            {
                var entites = await service.GetAllAsync(token);

                if (entites is null)
                    return Results.NotFound(ErrorMessage<Category>.ItemsNotFound());

                var categories = new List<Category>();
                categories.AddRange(entites.Select(c => new Category { Id = c.Id, Text = c.Text }));
                return Results.Ok(categories);
            });

        api.MapGet(
            "/{id}",
            async (string id, ICategoryService service, CancellationToken token) =>
            {
                var entity = await service.GetByIdAsync(id, token);
                if (entity is null)
                    return Results.NotFound(ErrorMessage<Category>.ItemNotFound(id));

                var catergory = new Category { Id = entity.Id, Text = entity.Text };
                return Results.Ok(catergory);
            });


        api.MapPost(
            "/",
            async (Category category, ICategoryService service, CancellationToken token) =>
            {
                var newCategory = new CategoryDocument() { Text = category.Text };
                await service.CreateAsync(newCategory, token);
                return Results.Ok(new Category { Id = newCategory.Id, Text = newCategory.Text });
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
