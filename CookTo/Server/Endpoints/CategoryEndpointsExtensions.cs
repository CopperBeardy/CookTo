using AutoMapper;
using CookTo.Server.Documents;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features;
using CookTo.Shared.Models;

namespace CookTo.Server.Endpoints;

public static class CategoryEndpointsExtensions
{
    public static void CategoryEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/api/category",
            async (ICategoryService service, IMapper mapper, CancellationToken token) =>
            {
                var categories = await service.GetAllAsync(token);
                return Results.Ok(mapper.Map<List<Category>>(categories));
            });

        app.MapGet(
            "/api/category/{id}",
            async (string id, ICategoryService service, IMapper mapper, CancellationToken token) =>
            {
                var category = await service.GetByIdAsync(id, token);
                if (category is null)
                {
                    return Results.BadRequest("Category was not found");
                }

                var response = mapper.Map<Category>(category);
                return Results.Ok(response);
            });


        app.MapPost(
            "/api/category",
            async (Category category, ICategoryService service, IMapper mapper, CancellationToken token) =>
            {
                var newcategory = mapper.Map<CategoryDocument>(category);
                await service.CreateAsync(newcategory, token);
                return Results.Ok(mapper.Map<Category>(newcategory));
            });
    }
}
