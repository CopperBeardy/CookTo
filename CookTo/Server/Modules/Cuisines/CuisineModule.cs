using AutoMapper;
using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Cuisines;

public class CuisineModule : IModule
{
    internal record Request(ICuisineService CuisineService, IMapper Mapper, CancellationToken CancellationToken);

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.CUISINE);
        api.MapGet("/{id}", GetByIdCuisine);
        api.MapGet("/", GetAllCuisines);
        api.MapPost("/", PostCuisine);
        return api;
    }

    internal static async Task<IResult> GetByIdCuisine(string id, [AsParameters] Request request) => await GenericHandlers<CuisineDocument, Cuisine>
    .GetByIdAsync(id, request.CuisineService, request.CancellationToken, request.Mapper);

    internal static async Task<IResult> GetAllCuisines([AsParameters] Request request) => await GenericHandlers<CuisineDocument, Cuisine>
        .GetAllAsync(request.CuisineService, request.CancellationToken, request.Mapper);

    internal static async Task<IResult> PostCuisine(Cuisine category, [AsParameters] Request request) => await GenericHandlers<CuisineDocument, Cuisine>
        .PostAsync(category, request.CuisineService, request.CancellationToken, request.Mapper, EndpointTemplate.CATEGORY_GET_REDIRECT);

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICuisineService, CuisineService>();
        return services;
    }
}
