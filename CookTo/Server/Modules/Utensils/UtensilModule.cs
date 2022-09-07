using AutoMapper;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;
using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server.Modules.Utensils;

public class UtensilModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.UTENSIL);
        api.MapGet("/{id}", GetByIdUtensil);
        api.MapGet("/", GetAllUtensils);
        api.MapPost("/", PostUtensil).RequireAuthorization();

        return api;
    }

    internal record Request(IUtensilService UtensilService, IMapper Mapper, CancellationToken CancellationToken);

    internal static async Task<IResult> GetByIdUtensil(string id, [AsParameters] Request request) => await GenericHandlers<UtensilDocument, Utensil>
      .GetByIdAsync(id, request.UtensilService, request.CancellationToken, request.Mapper);

    internal static async Task<IResult> GetAllUtensils([AsParameters] Request request) => await GenericHandlers<UtensilDocument, Utensil>
        .GetAllAsync(request.UtensilService, request.CancellationToken, request.Mapper);

    internal static async Task<IResult> PostUtensil(Utensil category, [AsParameters] Request request) => await GenericHandlers<UtensilDocument, Utensil>
        .PostAsync(category, request.UtensilService, request.CancellationToken, request.Mapper, EndpointTemplate.CATEGORY_GET_REDIRECT);


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IUtensilService, UtensilService>();
        return services;
    }
}
