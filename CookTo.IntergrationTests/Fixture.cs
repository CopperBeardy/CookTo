
using Microsoft.Extensions.Options;

namespace CookTo.Tests.Intergration;

public abstract  class Fixture 
{
	public ICookToDbContext CookToDbContext { get; set; }
	public string connectionString = "mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000";
	public string db = "CookTo";
	public Fixture()	   	{
		var settings = new MongoSettings(connectionString, db);
		IOptions<MongoSettings> options = Options.Create(settings);
		CookToDbContext = new CookToDbContext(options);
	}
}
