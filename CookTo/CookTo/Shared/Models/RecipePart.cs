using System.Text.Json.Serialization;

namespace CookTo.Shared.Models;

public class RecipePart
 {
	public int RecipePartId { get; set; }
    public int RecipeId { get; set; }
    public string Title { get; set; }
    public List<string> Ingredients { get; set; }
    public string CreationDate { get; set; }
}



