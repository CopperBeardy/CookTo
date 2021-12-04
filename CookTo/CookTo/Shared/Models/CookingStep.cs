using System.Text.Json.Serialization;

namespace CookTo.Shared.Models;

public class CookingStep
{
	public int CookingStepId { get; set; }
	public string Order { get; set; }
	public string Instruction { get; set; }
	public string CreationDate { get; set; }

}



