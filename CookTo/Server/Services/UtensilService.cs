using CookTo.Server.Documents.UtensilDocument;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class UtensilService : BaseService<Utensil>, IUtensilService
{
    public UtensilService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}