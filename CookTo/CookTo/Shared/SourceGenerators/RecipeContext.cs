using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using CookTo.Shared.Models;

namespace CookTo.Shared.SourceGenerators;


[JsonSerializable(typeof(Recipe))]
internal partial class RecipeContext : JsonSerializerContext
{

}


