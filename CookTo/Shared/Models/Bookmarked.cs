using CookTo.Shared.Rules;
using MongoDB.Bson;

namespace CookTo.Shared.Models;

public class Bookmarked
{
	[RequiredRule]
	public ObjectId RecipeId { get; set; }
	[RequiredRule]
	public string Title { get; set; }

}
