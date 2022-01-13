namespace CookTo.Shared.Rules;

public interface IModelRule
{
	ValidationResult Validate(String fieldname, object fieldValue);
}
