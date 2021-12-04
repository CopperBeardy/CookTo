using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using CookTo.Shared.Models;

namespace CookTo.Shared.SourceGenerators;


[JsonSerializable(typeof(UserBookmarks))]
internal partial class UserBookmarksContext : JsonSerializerContext
{

}


