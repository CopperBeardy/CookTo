﻿namespace CookTo.Server.DbContext;

public class MongoSettings
{
	public string Connection { get; set; }
	public string Database { get; set; }
	public MongoSettings(string connection,string database)
	{
		Connection = connection;
		Database = database;
	}

	
}