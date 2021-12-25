using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookTo.Shared.Enums;

namespace CookTo.Shared.Models;

public class RecipeThumbnail
{
	public string Id { get; set; }
	public string Title { get; set; }
	public string ImageUrl { get; set; }
	public Category Category { get; set; }
}
