using System.Text.Json.Serialization;

namespace CookTo.Shared.Models;

public class Ingredient
{
    public int IngredientId { get; set; }     
    public string MeasureUnit { get; set; }
    public int Amount { get; set; }
    public string Name { get; set; }
    public List<string> IngredientAlternatives { get; set; }
    public string CreationDate { get; set; }
}




