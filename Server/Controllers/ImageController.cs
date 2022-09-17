using CookTo.Shared;
using CookTo.Shared.Models.ManageRecipes;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;


namespace CookTo.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    MongoRepository<Recipe> repository;
    public ImageController(MongoRepository<Recipe> repository) => this.repository = repository;
    [HttpPost]
    public async Task<IResult> Post([FromBody]ImageUpload imageUpload)
    {
        var recipe = await repository.GetByIdAsync(imageUpload.RecipeId);
        if(recipe is null)
            return TypedResults.NotFound(ErrorMessage<Recipe>.ItemNotFound(imageUpload.RecipeId));

        if(imageUpload.Image.Length == 0)
            return TypedResults.BadRequest("No image found.");

        var filename = $"{Guid.NewGuid()}.jpg";
        var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

        var resizeOptions = new ResizeOptions { Mode = ResizeMode.Stretch, Size = new Size(640, 426) };

        using var image = Image.Load(imageUpload.Image);
        image.Mutate(x => x.Resize(resizeOptions));
        await image.SaveAsJpegAsync(saveLocation);

        if(!string.IsNullOrWhiteSpace(recipe.Image))
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", recipe.Image));

        recipe.Image = filename;
        await repository.Update(recipe);

        return TypedResults.Ok(recipe.Image);
    }
}
