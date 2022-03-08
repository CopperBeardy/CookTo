using CookTo.Server.Documents.CuisineDocument;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class CuisineService : BaseService<Cuisine>, ICuisineService
{
    public CuisineService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}