using AutoMapper;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;
using CookTo.DataAccess.Documents.TipDocumentAccess;
using CookTo.DataAccess.Documents.TipDocumentAccess;
using CookTo.DataAccess.Documents.TipDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageTips;
using Microsoft.Extensions.Azure;

namespace CookTo.Server.Modules.Tips;

public class TipModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.TIP);
        api.MapGet("/{id}", GetByIdTip);
        api.MapGet("/", GetAllTips);
        api.MapPost("/", PostTip).RequireAuthorization();
        return api;
    }

    internal record Request(ITipService TipService, IMapper Mapper, CancellationToken CancellationToken);
    internal static async Task<IResult> GetByIdTip(string id, [AsParameters] Request request) => await GenericHandlers<TipDocument, Tip>
    .GetByIdAsync(id, request.TipService, request.CancellationToken, request.Mapper);

    internal static async Task<IResult> GetAllTips([AsParameters] Request request) => await GenericHandlers<TipDocument, Tip>
        .GetAllAsync(request.TipService, request.CancellationToken, request.Mapper);

    internal static async Task<IResult> PostTip(Tip category, [AsParameters] Request request) => await GenericHandlers<TipDocument, Tip>
        .PostAsync(category, request.TipService, request.CancellationToken, request.Mapper, EndpointTemplate.CATEGORY_GET_REDIRECT);


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ITipService, TipService>();
        return services;
    }
}
