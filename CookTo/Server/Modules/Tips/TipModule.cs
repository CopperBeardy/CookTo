using AutoMapper;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;
using CookTo.DataAccess.Documents.TipDocumentAccess;
using CookTo.DataAccess.Documents.TipDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageTips;
using Microsoft.Extensions.Azure;

namespace CookTo.Server.Modules.Tips;

public class TipModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.TIP);
        api.MapGet("/", GetAllTips);
        api.MapGet("/{id}", GetByIdTip);
        api.MapPost("/", PostTip).RequireAuthorization();
        return api;
    }

    internal record Request(ITipService TipService, IMapper Mapper, CancellationToken CancellationToken);

    internal static async Task<IResult> GetAllTips([AsParameters] Request request)
    {
        var entites = await request.TipService.GetAllAsync(request.CancellationToken);
        var response = new List<Tip>();

        if(entites is not null || entites.Any())
            response.AddRange(entites.Select(c => request.Mapper.Map<Tip>(c)));

        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> GetByIdTip(string id, [AsParameters] Request request)
    {
        var document = await request.TipService.GetByIdAsync(id, request.CancellationToken);
        if(document is null)
            return TypedResults.NotFound(ErrorMessage<Tip>.ItemNotFound(id));

        var response = request.Mapper.Map<Tip>( document);
        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> PostTip(Tip category, [AsParameters] Request request)
    {
        var document = request.Mapper.Map<TipDocument>(category);
        await request.TipService.CreateAsync(document, request.CancellationToken);
        var response = request.Mapper.Map<Tip>(document);
        return TypedResults.Created($"{EndpointTemplate.CATEGORY_REDIRECT}/{response.Id}", response);
    }


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ITipService, TipService>();
        return services;
    }
}
