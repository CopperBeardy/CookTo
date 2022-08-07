using CookTo.Server.Modules.Cuisines.Core;


namespace CookTo.Server.Modules.Cuisines.Services;

public class CuisineService : BaseService<CuisineDocument>, ICuisineService
{
    public CuisineService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}