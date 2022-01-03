using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.Shared.Rules;

public class RequiredRule : Attribute, IModelRule
{
	public ValidationResult Validate(string fieldname, object fieldValue)
	{
		var message = $"Required";
		if(fieldValue == null)
		{
			return new ValidationResult()
			{
				IsValid = false,
				Message = message
			};
		}

		if(String.IsNullOrWhiteSpace(fieldValue.ToString()))
		{
			return new ValidationResult()
			{
				IsValid = false,
				Message = message
			};
		}
		else
		{
			return new ValidationResult()
			{
				IsValid = true
			};
		}
	}
}
