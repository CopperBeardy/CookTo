using CookTo.Server.Documents.UtensilDocument;
using CookTo.Shared.Features.ManageUtensils.Shared;

namespace CookTo.Server.Mappings;

public static class UtensilMapping
{
    public static Utensil FromDtoToUtensil(UtensilDto obj)
    { return new Utensil() { Id = obj.Id, UtensilName = obj.UtensilName }; }

    public static UtensilDto FromUtensilToDto(Utensil obj)
    { return new UtensilDto() { Id = obj.Id, UtensilName = obj.UtensilName }; }
}
