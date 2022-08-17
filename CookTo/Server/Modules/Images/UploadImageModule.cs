using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Images.Handlers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;


namespace CookTo.Server.Modules.Images;

public class UploadImageModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.UPLOADIMAGE);

        api.MapPost("/", async (ImageUpload imageUpload, IRecipeService service, CancellationToken cancellationToken) => await UploadImage.Handle(imageUpload, service, cancellationToken))
            .RequireAuthorization();

        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services) => services;
}
