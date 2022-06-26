﻿using AutoMapper;
using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Categories.Services;
using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Server.Modules.Categories;

public  class CategoryModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/api");
        api.MapGet(
            "/category",
            async (ICategoryService service, IMapper mapper, CancellationToken token) =>
            {
                var categories = await service.GetAllAsync(token);
                return Results.Ok(mapper.Map<List<Category>>(categories));
            });

        api.MapGet(
            "/category/{id}",
            async (string id, ICategoryService service, IMapper mapper, CancellationToken token) =>
            {
                var category = await service.GetByIdAsync(id, token);
                if(category is null)
                {
                    return Results.BadRequest("Category was not found");
                }

                var response = mapper.Map<Category>(category);
                return Results.Ok(response);
            });


        api.MapPost(
            "/category",
            async (Category category, ICategoryService service, IMapper mapper, CancellationToken token) =>
            {
                var newcategory = mapper.Map<CategoryDocument>(category);
                await service.CreateAsync(newcategory, token);
                return Results.Ok(mapper.Map<Category>(newcategory));
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
