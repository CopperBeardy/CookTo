using CookTo.Shared.Enums;
using CookTo.Shared.Models;

namespace CookTo.Client.ViewModels;

public class PartIngredient
{
	public double Amount { get; set; } = 0;

	public MeasureUnit Unit { get; set; } = MeasureUnit.g;

	public Ingredient Ingredient { get; set; } = new Ingredient();

	public string Description { get; set; } = string.Empty;
}
