using AutoMapper;
using CookTo.Server.Modules.Ingredients.Core;
using CookTo.Server.Modules.Ingredients.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Ingredients;

public  class IngredientModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/ingredient");
        api.MapGet(
            "/",
            async (IIngredientService service, CancellationToken token) =>
            {
                var entites = await service.GetAllAsync(token);

                if(entites is null)
                    return Results.NotFound(ErrorMessage<Ingredient>.ItemsNotFound());

                var ingredients = new List<Ingredient>();
                ingredients.AddRange(entites.Select(c => new Ingredient { Id = c.Id, Text = c.Text }));
                return Results.Ok(ingredients);
            });


        api.MapPost(
            "/",
            async (Ingredient ingredient, IIngredientService service, CancellationToken token) =>
            {
                var newIngredient = new IngredientDocument { Id = ingredient.Id, Text = ingredient.Text };
                await service.CreateAsync(newIngredient, token);
                return Results.Ok(new Ingredient { Id = newIngredient.Id, Text = newIngredient.Text });
            })
            .RequireAuthorization();
        return api;
    }


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IIngredientService, IngredientService>();
        return services;
    }
}
