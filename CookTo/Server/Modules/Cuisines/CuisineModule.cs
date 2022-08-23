using AutoMapper;
using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;

using CookTo.Shared;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Cuisines;


public class CuisineModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.CUISINE);
        api.MapGet("/", GetAllCuisines);
        api.MapGet("/{id}", GetByIdCuisines);

        api.MapPost("/", PostCuisine);

        return api;
    }

    internal record Request(ICuisineService CuisineService, IMapper Mapper, CancellationToken CancellationToken);

    internal static async Task<IResult> GetAllCuisines([AsParameters] Request request)
    {
        var entites = await request.CuisineService.GetAllAsync(request.CancellationToken);
        var response = new List<Cuisine>();

        if(entites is not null || entites.Any())
            response.AddRange(entites.Select(c => request.Mapper.Map<Cuisine>(c)));

        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> GetByIdCuisines(string id, [AsParameters] Request request)
    {
        var document = await request.CuisineService.GetByIdAsync(id, request.CancellationToken);
        if(document is null)
            return TypedResults.NotFound(ErrorMessage<Cuisine>.ItemNotFound(id));

        var response = request.Mapper.Map<Cuisine>(document);
        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> PostCuisine(Cuisine cuisine, [AsParameters] Request request)
    {
        var newCuisine = request.Mapper.Map<CuisineDocument>(cuisine);
        await request.CuisineService.CreateAsync(newCuisine, request.CancellationToken);
        var response = request.Mapper.Map<Cuisine>(newCuisine);
        return TypedResults.Created($"{EndpointTemplate.CATEGORY_REDIRECT}/{response.Id}", response);
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICuisineService, CuisineService>();
        return services;
    }
}
