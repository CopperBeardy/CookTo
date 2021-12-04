using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookTo.Shared.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;

namespace CookTo.Server.Services;

public class CosmosRecipeDbService  : ICosmosRecipeDbService
{
    private Container _container;

    public CosmosRecipeDbService(
        CosmosClient dbClient,
        string databaseName,
        string containerName)
    {
        this._container = dbClient.GetContainer(databaseName, containerName);
    }

    public async Task AddRecipeAsync(Recipe recipe)
    {
        await this._container.CreateItemAsync<Recipe>(recipe, new PartitionKey(recipe.RecipeId));
    }

    public async Task DeleteRecipeAsync(string recipeId)
    {
        await this._container.DeleteItemAsync<Recipe>(recipeId, new PartitionKey(recipeId));
    }

    public async Task<Recipe> GetRecipeAsync(string recipeId)
    {
        try
        {
            ItemResponse<Recipe> response = await this._container.ReadItemAsync<Recipe>(recipeId, new PartitionKey(recipeId));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

    }

    public async Task<IEnumerable<Recipe>> GetRecipesAsync(string queryString)
    {
        var query = this._container.GetItemQueryIterator<Recipe>(new QueryDefinition(queryString));
        List<Recipe> results = new List<Recipe>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();

            results.AddRange(response.ToList());
        }

        return results;
    }

    public async Task UpdateRecipeAsync(string id, Recipe Recipe)
    {
        await this._container.UpsertItemAsync<Recipe>(Recipe, new PartitionKey(id));
    }
}

