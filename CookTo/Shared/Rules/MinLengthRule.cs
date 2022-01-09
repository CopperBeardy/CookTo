using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.Shared.Rules;

public class MinLengthRule : Attribute, IModelRule
{
	private readonly int minLength;
	public MinLengthRule(int minValue)
	{
		  minLength = minValue;
	}
	public ValidationResult Validate(string fieldname, object fieldValue)
	{
		ValidationResult result = new ();
		var message = $"cannot be shorted than {minLength} characters";
		if(fieldValue == null)
		{
			result.IsValid = true;
			return result;
		}

		var stringValue = fieldValue.ToString();
		if(stringValue.Length < minLength)
		{
			result.IsValid = false;
			result.Message = message;
			return result;
		}
		else
		{
			result.IsValid = true;
			return result;
		}
	}
}
