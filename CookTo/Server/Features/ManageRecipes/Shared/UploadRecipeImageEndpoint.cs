using Ardalis.ApiEndpoints;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageRecipes.Shared;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CookTo.Server.Features.ManageRecipes.Shared;

public class UploadRecipeImageEndpoint : EndpointBaseAsync.WithRequest<string>.WithActionResult<string>
{
    readonly IRecipeService _recipeService;

    public UploadRecipeImageEndpoint(IRecipeService recipeService) { _recipeService = recipeService; }

    [HttpPost(UploadRecipeImageRequest.RouteTemplate)]
    public override async Task<ActionResult<string>> HandleAsync(
        [FromRoute] string recipeId,
        CancellationToken cancellationToken = default)
    {
        var recipe = await _recipeService.GetByIdAsync(recipeId, cancellationToken);
        if(recipe is null)
        {
            return BadRequest("Recipe does not exist.");
        }

        var file = Request.Form.Files[0];
        if(file.Length == 0)
        {
            return BadRequest("No image found.");
        }

        var filename = $"{Guid.NewGuid()}.jpg";
        var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

        var resizeOptions = new ResizeOptions { Mode = ResizeMode.Pad, Size = new Size(640, 426) };

        using var image = Image.Load(file.OpenReadStream());
        image.Mutate(x => x.Resize(resizeOptions));
        await image.SaveAsJpegAsync(saveLocation, cancellationToken: cancellationToken);

        if(!string.IsNullOrWhiteSpace(recipe.Image))
        {
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", recipe.Image));
        }

        recipe.Image = filename;
        await _recipeService.UpdateAsync(recipe, cancellationToken);

        return Ok(recipe.Image);
    }
}