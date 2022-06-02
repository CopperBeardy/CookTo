using CookTo.Server.Documents;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class UtensilService : BaseService<UtensilDocument>, IUtensilService
{
    public UtensilService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}