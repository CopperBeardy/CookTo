using CookTo.Server.Documents;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Models;

namespace CookTo.Server.Services;

public class CuisineService : BaseService<CuisineDocument>, ICuisineService
{
    public CuisineService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}