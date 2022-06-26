using Microsoft.AspNetCore.Components.Forms;

namespace CookTo.Client.HttpManagers.Interfaces;

public interface IUploadImageManager
{
    Task<IBrowserFile> GetImage(string recipeId);

    Task<string> UploadImage(string recipeId, IBrowserFile file);
}
