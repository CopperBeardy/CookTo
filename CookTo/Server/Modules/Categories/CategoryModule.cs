using AutoMapper;
using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Server.Modules.Categories;

public class CategoryModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.CATEGORY);
        api.MapGet("/{id}", GetByIdCategory);
        api.MapGet("/", GetAllCategories);
        api.MapPost("/", PostCategory);

        return api;
    }

    public  record Request(ICategoryService CategoryService, IMapper Mapper, CancellationToken CancellationToken);

    internal static async Task<IResult> GetByIdCategory(string id, [AsParameters] Request request)
    {
        var document = await request.CategoryService.GetByIdAsync(id, request.CancellationToken);
        if(document is null)
            return TypedResults.NotFound(ErrorMessage<Category>.ItemNotFound(id));

        var response = request.Mapper.Map<Category>(document);
        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> GetAllCategories([AsParameters] Request request)
    {
        var entites = await request.CategoryService.GetAllAsync(request.CancellationToken);
        var response = new List<Category>();

        if(entites is not null || entites.Any())
            response.AddRange(entites.Select(c => request.Mapper.Map<Category>(c)));

        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> PostCategory(Category category, [AsParameters] Request request)
    {
        var newCategory = request.Mapper.Map<CategoryDocument>(category);
        await request.CategoryService.CreateAsync(newCategory, request.CancellationToken);
        var response = request.Mapper.Map<Category>(newCategory);
        return TypedResults.Created($"{EndpointTemplate.CATEGORY_REDIRECT}/{response.Id}", response);
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}

