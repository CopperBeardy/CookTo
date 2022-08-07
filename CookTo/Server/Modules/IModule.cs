namespace CookTo.Server.Modules;

public interface IModule
{
    IServiceCollection RegisterModule(IServiceCollection services);

    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
