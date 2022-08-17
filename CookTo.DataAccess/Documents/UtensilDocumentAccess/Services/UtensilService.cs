
using CookTo.DataAccess.DbContext;

namespace CookTo.DataAccess.Documents.UtensilDocumentAccess.Services;

public class UtensilService : BaseService<UtensilDocument>, IUtensilService
{
    public UtensilService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}