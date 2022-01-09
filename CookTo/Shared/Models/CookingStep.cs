using CookTo.Shared.Rules;
using System;
using System.Linq;

namespace CookTo.Shared.Models;

public class CookingStep
{
	[RequiredRule]
	public int StepOrder { get; set; }

	[RequiredRule]
	[MinLengthRule(10)]
	public string Step { get; set; }


}
