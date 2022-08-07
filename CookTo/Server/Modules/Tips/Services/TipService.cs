using CookTo.Server.Modules.Tips.Core;

namespace CookTo.Server.Modules.Tips.Services;

public class TipService : BaseService<TipDocument>, ITipService
{
    public TipService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}
