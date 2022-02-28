using AutoMapper;
using CookTo.Server.Documents.CuisineDocument;
using CookTo.Server.Helpers;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageCuisine;

namespace CookTo.Server.Endpoints;

public static class CuisineEndpointsExtensions
{
    public static void CuisineEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/api/cuisine",
            async (ICuisineService service, IMapper mapper, CancellationToken token) =>
            {
                var cuisines = await service.GetAllAsync(token);
                return Results.Ok(mapper.Map<List<CuisineDto>>(cuisines));
            });

        app.MapGet(
            "/api/cuisine/{id}",
            async (string id, ICuisineService service, IMapper mapper, CancellationToken token) =>
            {
                var cuisine = await service.GetByIdAsync(id, token);
                if(cuisine is null)
                {
                    return Results.BadRequest("Ingredient was not found");
                }

                var response = mapper.Map<CuisineDto>(cuisine);
                return Results.Ok(response);
            });


        app.MapPost(
            "/api/cuisine",
            async (CuisineDto cuisine, ICuisineService service, IMapper mapper, CancellationToken token) =>
            {
                var newCuisine = CuisineFormatter.Format(mapper.Map<Cuisine>(cuisine));
                await service.CreateAsync(newCuisine, token);
                return Results.Ok(mapper.Map<CuisineDto>(newCuisine));
            });
    }
}
