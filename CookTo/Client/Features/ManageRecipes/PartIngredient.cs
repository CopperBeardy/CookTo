namespace CookTo.Client.Features.ManageRecipes;

public class PartIngredient
{
	public double Amount { get; set; } = default;

	public MeasureUnit Unit { get; set; } = MeasureUnit.g;

	public string Name { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;
}
