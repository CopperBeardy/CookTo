using Microsoft.AspNetCore.Http;

namespace CookTo.Shared.Features.ManageRecipes;

public class ImageUploadDto
{
    [JsonPropertyName(("recipe_id"))]
    public string RecipeId { get; set; }

    [JsonPropertyName("file")]
    public IFormFile File { get; set; }
}
