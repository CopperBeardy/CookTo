using Microsoft.AspNetCore.Components.Forms;

namespace CookTo.Client.Services;

public interface IImageManager
{
    Task<string> UploadImage(string recipeId, IBrowserFile file);
}
