﻿using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.DataAccess.SeedDataJson;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CookTo.DataAccess.DbContext;

public class CookToDbContext : ICookToDbContext
{
    private readonly MongoClient client;
    private readonly IMongoDatabase db;

    public CookToDbContext(IOptions<MongoSettings> configuration)
    {
        //client = new MongoClient(configuration.Value.Connection);
        //db = client.GetDatabase(configuration.Value.Database);
        client = new MongoClient(configuration.Value.Connection);

        db = client.GetDatabase(configuration.Value.Database);
    }

    public  void HasSeeded(IMongoDatabase db)
    {
        if(!db.ListCollections().Any())
        {
            Seeder.Seed(db);
        }
    }

    public IMongoCollection<T> GetCollection<T>(string name) => db.GetCollection<T>(name);
}
