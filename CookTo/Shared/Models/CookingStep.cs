using CookTo.Shared.Rules;

namespace CookTo.Shared.Models;

public class CookingStep
{
	[RequiredRule]
	[JsonPropertyName("stepnumber")]
	public int StepNumber { get; set; }

	[RequiredRule]
	[MinLengthRule(10)]
	[JsonPropertyName("step")]
	public string Step { get; set; }
}
