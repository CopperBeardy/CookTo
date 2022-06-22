using CookTo.Server.Modules;
using CookTo.Server.Modules.Utensils.Core;

namespace CookTo.Server.Modules.Utensils.Services;

public class UtensilService : BaseService<UtensilDocument>, IUtensilService
{
    public UtensilService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}