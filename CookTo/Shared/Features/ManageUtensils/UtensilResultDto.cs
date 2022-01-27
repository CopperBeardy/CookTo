using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.Shared.Features.ManageUtensils;

public class UtensilResultDto
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("requiredAmount")]
    public int RequiredAmount { get; set; }

    [JsonPropertyName("utensilName")]
    public string UtensilName { get; set; } = string.Empty;
}
