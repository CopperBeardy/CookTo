using AutoMapper;
using CookTo.Server.Documents.CategoryDocument;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageCategory;

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
                return Results.Ok(mapper.Map<List<CategoryDto>>(categories));
            });

        app.MapGet(
            "/api/category/{id}",
            async (string id, ICategoryService service, IMapper mapper, CancellationToken token) =>
            {
                var category = await service.GetByIdAsync(id, token);
                if(category is null)
                {
                    return Results.BadRequest("Category was not found");
                }

                var response = mapper.Map<CategoryDto>(category);
                return Results.Ok(response);
            });


        app.MapPost(
            "/api/category",
            async (CategoryDto category, ICategoryService service, IMapper mapper, CancellationToken token) =>
            {
                var newcategory = CategoryFormatter.Format(mapper.Map<Category>(category));
                await service.CreateAsync(newcategory, token);
                return Results.Ok(mapper.Map<CategoryDto>(newcategory));
            });
    }
}
