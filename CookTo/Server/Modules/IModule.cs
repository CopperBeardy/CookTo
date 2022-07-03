namespace CookTo.Server.Modules;

public interface IModule
{
    IServiceCollection RegisterModule(IServiceCollection services);

    GroupRouteBuilder MapEndpoints(GroupRouteBuilder endpoints);
}
