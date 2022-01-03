using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.Shared.Rules;

public interface IModelRule
{
	ValidationResult Validate(String fieldname, object fieldValue);
}
