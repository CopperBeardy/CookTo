
using CookTo.Server.Documents.UtensilDocument;

namespace CookTo.Server.Services.Interfaces;

public interface IUtensilService : IBaseService<Utensil>
{
    Task Seed();
}


