

using CookTo.DataAccess.DbContext;

namespace CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;

public class CuisineService : BaseService<CuisineDocument>, ICuisineService
{
    public CuisineService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}