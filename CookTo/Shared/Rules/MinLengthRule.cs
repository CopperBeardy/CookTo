using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.Shared.Rules;

public class MinLengthRule : Attribute, IModelRule
{
	private int _minLength = 0;
	public MinLengthRule(int minValue)
	{
		  _minLength = minValue;
	}
	public ValidationResult Validate(string fieldname, object fieldValue)
	{
		ValidationResult result = new ValidationResult();
		var message = $"cannot be shorted than {_minLength} characters";
		if(fieldValue == null)
		{
			result.IsValid = true;
			return result;
		}

		var stringValue = fieldValue.ToString();
		if(stringValue.Length < _minLength)
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
