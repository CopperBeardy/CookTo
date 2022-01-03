using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookTo.Shared.Rules;

namespace CookTo.Shared.Models;

public class CookingStep
{
	[RequiredRule]
	public int StepOrder { get; set; }
	[RequiredRule]
	[MinLengthRule(10)]
	public string Step { get; set; }
}
