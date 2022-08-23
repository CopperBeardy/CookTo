using AutoMapper;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;
using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server.Modules.Utensils;

public class UtensilModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.UTENSIL);
        api.MapGet("/", GetAllUtensils);
        api.MapGet("/{id}", GetByIdUtensil);
        api.MapPost("/", PostUtensil).RequireAuthorization();

        return api;
    }

    internal record Request(IUtensilService UtensilService, IMapper Mapper, CancellationToken CancellationToken);

    internal static async Task<IResult> GetAllUtensils([AsParameters] Request request)
    {
        var documents = await request.UtensilService.GetAllAsync(request.CancellationToken);
        var response = new List<Utensil>();

        if(documents is not null || documents.Any())
            response.AddRange(documents.Select(c => request.Mapper.Map<Utensil>(c)));

        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> GetByIdUtensil(string id, [AsParameters] Request request)
    {
        var document = await request.UtensilService.GetByIdAsync(id, request.CancellationToken);
        if(document is null)
            return TypedResults.NotFound(ErrorMessage<Utensil>.ItemNotFound(id));

        var response = request.Mapper.Map<Utensil>(document);
        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> PostUtensil(Utensil category, [AsParameters] Request request)
    {
        var document = request.Mapper.Map<UtensilDocument>(category);
        await request.UtensilService.CreateAsync(document, request.CancellationToken);
        var response = request.Mapper.Map<Utensil>(document);
        return TypedResults.Created($"{EndpointTemplate.CATEGORY_REDIRECT}/{response.Id}", response);
    }


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IUtensilService, UtensilService>();
        return services;
    }
}
