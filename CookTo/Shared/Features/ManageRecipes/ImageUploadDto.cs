using Microsoft.AspNetCore.Http;

namespace CookTo.Shared.Features.ManageRecipes;

public class ImageUploadDto
{
    public string RecipeId { get; set; }


    public IFormFile File { get; set; }
}
