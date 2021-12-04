using System.Text.Json.Serialization;

namespace CookTo.Shared.Models;

public class Tip
    {
	public int TipId { get; set; }
	public int RecipeId { get; set; }
    public string Description { get; set; }
 
    public string CreationDate { get; set; }
}



