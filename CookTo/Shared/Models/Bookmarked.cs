using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace CookTo.Shared.Models;

public class Bookmarked
{
	public ObjectId RecipeId { get; set; }
	public string Title { get; set; }
}
