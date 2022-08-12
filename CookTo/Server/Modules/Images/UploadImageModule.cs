using CookTo.Server.Modules.Images.Handlers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;


namespace CookTo.Server.Modules.Images;

public class UploadImageModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.UPLOADIMAGE);

        api.MapPost("/", async (ImageUpload imageUpload, [AsParameters]CommonParameters cp) => await UploadImage.Handle(imageUpload, cp))
            .RequireAuthorization();

        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services) => services;
}
