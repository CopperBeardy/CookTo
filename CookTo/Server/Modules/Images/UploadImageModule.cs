using CookTo.Server.Modules.RecipeHighlighted.Services;
using CookTo.Server.Modules.Recipes.Core;
using CookTo.Server.Modules.Recipes.Services;
using CookTo.Server.Modules.RecipeSummaries.Services;
using CookTo.Shared.Modules.ManageRecipes;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CookTo.Server.Modules.Images;

public  class UploadImageModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(
            "/upload",
            async (ImageUpload dto, IRecipeService service, IRecipeSummaryService summaryService, IRecipeHighlightedService recipeHighlightedService , CancellationToken token) =>
            {
                var recipe = await service.GetByIdAsync(dto.RecipeId, token);
                if(recipe is null)
                    return Results.BadRequest("Recipe does not exist.");

                if(dto.Image.Length == 0)
                    return Results.BadRequest("No image found.");

                var filename = $"{Guid.NewGuid()}.jpg";
                var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

                var resizeOptions = new ResizeOptions { Mode = ResizeMode.Stretch, Size = new Size(640, 426) };

                using var image = Image.Load(dto.Image);
                image.Mutate(x => x.Resize(resizeOptions));
                await image.SaveAsJpegAsync(saveLocation, cancellationToken: token);

                if(!string.IsNullOrWhiteSpace(recipe.Image))
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", recipe.Image));

                await HandleRecipeUpdate(service, recipe, filename, token);

                await HandleSummaryUpdate(dto.RecipeId, summaryService, filename, token);

                await HandleHighlightedRecipeUpdate(dto.RecipeId, recipeHighlightedService, filename, token);

                return Results.Ok(recipe.Image);
            })
            .RequireAuthorization();
        return endpoints;
    }

    private static async Task HandleRecipeUpdate(IRecipeService service, RecipeDocument recipe, string filename, CancellationToken token)
    {
        recipe.Image = filename;
        await service.UpdateAsync(recipe, token);
    }

    private static async Task HandleHighlightedRecipeUpdate(string id, IRecipeHighlightedService recipeHighlightedService, string filename, CancellationToken token)
    {
        var highlighted = await recipeHighlightedService.GetAsync(token);
        if(id == highlighted.Id)
        {
            highlighted.Image = filename;
            await recipeHighlightedService.UpdateAsync(highlighted, token);
        }
    }

    private static async Task HandleSummaryUpdate(string id, IRecipeSummaryService summaryService, string filename, CancellationToken token)
    {
        var summary = await summaryService.GetByIdAsync(id, token);
        summary.Image = filename;
        await summaryService.UpdateAsync(summary, token);
    }

    public IServiceCollection RegisterModule(IServiceCollection services) { return services; }
}
