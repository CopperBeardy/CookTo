using CookTo.Shared.Rules;

namespace CookTo.Shared.Models;

public class ModelBase
{
	private Dictionary<string, Dictionary<string, string>> errors = new();
	public event EventHandler<EventArgs> ModelChanged;
	private void AddError(string fieldName, string ruleName, string errorText)
	{
		if (!errors.ContainsKey(fieldName))
		{
			errors.Add(fieldName, new Dictionary<string, string>());
		}
		if (errors[fieldName].ContainsKey(ruleName))
		{
			errors[fieldName].Remove(ruleName);
		}
		errors[fieldName].Add(ruleName, errorText);
		OnModelChanged();
	}

	private void RemoveError(string fieldName, string ruleName)
	{
		if (!errors.ContainsKey(fieldName))
		{
			errors.Add(fieldName, new Dictionary<string, string>());
		}
		if (errors[fieldName].ContainsKey(ruleName))
		{
			errors[fieldName].Remove(ruleName);
		}
		OnModelChanged();
	}

	public void CheckRules(string fieldName)
	{
		var propertyInfo = this.GetType().GetProperty(fieldName);
		var attrInfos = propertyInfo.GetCustomAttributes(true);
		foreach (var attrInfo in attrInfos)
		{
			if (attrInfo is IModelRule modelRule)
			{
				var value = propertyInfo.GetValue(this);
				var result = modelRule.Validate(fieldName, value);
				if (result.IsValid)
				{
					RemoveError(fieldName, attrInfo.GetType().Name);
				}
				else
				{
					AddError(fieldName, attrInfo.GetType().Name, result.Message);
				}
			}
		}
	}

	public bool CheckRules()
	{
		foreach (var propInfo in this.GetType().GetProperties(
			System.Reflection.BindingFlags.Public |
			System.Reflection.BindingFlags.Instance))
			CheckRules(propInfo.Name);

		return HasErrors();
	}

	public bool HasErrors()
	{
		foreach (var key in errors.Keys)
		{
			if (errors[key].Keys.Count > 0)
			{
				return true;
			}
		}
		return false;
	}

	public string GetValue(string fieldName)
	{
		var propertyInfo = this.GetType().GetProperty(fieldName);
		var value = propertyInfo.GetValue(this);
		if (value != null)
		{
			return value.ToString();
		}
		return string.Empty;
	}

	public void SetValue(string fieldName, object value)
	{
		var propertyInfo = this.GetType().GetProperty(fieldName);
		propertyInfo.SetValue(this, value);
		CheckRules(fieldName);
	}

	protected void OnModelChanged()
	{
		ModelChanged?.Invoke(this, new EventArgs());
	}
}
