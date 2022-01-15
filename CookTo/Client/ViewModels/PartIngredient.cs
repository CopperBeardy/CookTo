using CookTo.Shared.Enums;
using CookTo.Shared.Models;

namespace CookTo.Client.ViewModels;

public class PartIngredient
{
	public double Amount { get; set; }

	public MeasureUnit Unit { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }
}
