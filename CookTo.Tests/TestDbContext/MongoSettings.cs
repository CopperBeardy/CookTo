namespace CookTo.Tests.TestDbContext;

public class MongoSettings
{
	public string Connection { get; set; } =
		"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000";
	public string Database { get; set; } =
		"CookTo";
}