using CookTo.Server.Documents.UtensilDocument;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class UtensilService : BaseService<Utensil>, IUtensilService
{
    public UtensilService(ICookToDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Seed()
    {
        var utensils = new List<Utensil>()
        {
            new Utensil() { UtensilName = "Muffin Moulds" },
            new Utensil() { UtensilName = "20cm loose fitting Cake Tin" },
            new Utensil() { UtensilName = "Whisk" },
            new Utensil() { UtensilName = "Electric Whisk" },
        };

        await dbCollection.InsertManyAsync(utensils);
    }
}