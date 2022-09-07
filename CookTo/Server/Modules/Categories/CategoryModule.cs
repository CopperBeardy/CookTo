using AutoMapper;
using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Server.Modules.Categories;

public class CategoryModule : IModule
{
    public  record Request(ICategoryService CategoryService, IMapper Mapper, CancellationToken CancellationToken);

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.CATEGORY);
        api.MapGet("/{id}", GetByIdCategory).WithName("GetCategoryById");
        api.MapGet("/", GetAllCategories).WithName("GetListOfCategories");
        api.MapPost("/", PostCategory).WithName("CreateNewCategory");

        return api;
    }

    internal static async Task<IResult> GetByIdCategory(string id, [AsParameters] Request request) =>
        await GenericHandlers<CategoryDocument, Category>
        .GetByIdAsync(id, request.CategoryService, request.CancellationToken, request.Mapper);

    internal static async Task<IResult> GetAllCategories([AsParameters] Request request) =>
        await GenericHandlers<CategoryDocument, Category>
        .GetAllAsync(request.CategoryService, request.CancellationToken, request.Mapper);

    internal static async Task<IResult> PostCategory(Category category, [AsParameters] Request request) =>
        await GenericHandlers<CategoryDocument, Category>
        .PostAsync(category, request.CategoryService, request.CancellationToken, request.Mapper, EndpointTemplate.CATEGORY_GET_REDIRECT);

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}

