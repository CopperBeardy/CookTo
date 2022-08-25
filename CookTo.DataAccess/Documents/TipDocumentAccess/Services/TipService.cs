

using CookTo.DataAccess.DbContext;

namespace CookTo.DataAccess.Documents.TipDocumentAccess.Services;

public class TipService : BaseService<TipDocument>, ITipService
{
    public TipService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}
