//using CookTo.Server.DbContext;
//using CookTo.Shared.Enums;
//using CookTo.Shared.Models;
//using MongoDB.Driver;

//namespace CookTo.Server.Services;

//public class RecipeService
//{
//	private readonly ICookToDbContext _dbContext;
//	public RecipeService(ICookToDbContext dbContext)
//	{
//		_dbContext = dbContext;
//	}

//	public async Task<List<RecipeThumbnail>> GetRecipesAsync()
//	{
//		try
//		{
//			var recipeProject = Builders<Recipe>.Projection
//				.Include(r => r.Id)
//				.Include(r => r.ImageURL)
//				.Include(r => r.Title)
//				.Include(r => r.Category);
//			return await _dbContext.Recipes.Find(_ => true)
//				.Project<RecipeThumbnail>(recipeProject)
//				.ToListAsync()
//				.ConfigureAwait(false);
//		}
//		catch (Exception)
//		{

//			throw;
//		}
//	}

//	public async Task<List<RecipeThumbnail>> GetRecipeThumbnailsByCategoryAsync(Category category)
//	{
//		try
//		{
//			var categoryFilter = Builders<Recipe>.Filter
//				.Eq(c => c.Category, Enum.GetName(category));
//			var recipeProject = Builders<Recipe>.Projection
//				.Include(r => r.Id)
//				.Include(r => r.ImageURL)
//				.Include(r => r.Title)
//				.Include(r => r.Category);
//			return await _dbContext.Recipes
//				.Aggregate()
//				.Match(categoryFilter)
//				.Project<RecipeThumbnail>(recipeProject)
//				.ToListAsync();
//		}
//		catch (Exception)
//		{

//			throw;
//		}
//	}
//	public async Task CreateRecipeAsync(Recipe recipe)
//	{
//		try
//		{
//			await _dbContext.Recipes.InsertOneAsync(recipe);
//		}
//		catch
//		{
//			throw;
//		}
//	}
//	public async Task<Recipe> GetRecipeByIdAsync(string id)
//	{
//		try
//		{
//			FilterDefinition<Recipe> recipeFilter = Builders<Recipe>.Filter.Eq("Id", id);
//			return await _dbContext.Recipes.FindSync(recipeFilter).FirstOrDefaultAsync();
//		}
//		catch
//		{
//			throw;
//		}
//	}
//	public async Task UpdateRecipeAsync(Recipe recipe)
//	{
//		try
//		{
//			await _dbContext.Recipes.ReplaceOneAsync(filter: g => g.Id == recipe.Id, replacement: recipe);
//		}
//		catch
//		{
//			throw;
//		}
//	}
//	public async Task DeleteRecipeAsync(string id)
//	{
//		try
//		{
//			FilterDefinition<Recipe> recipeData = Builders<Recipe>.Filter.Eq("Id", id);
//			await _dbContext.Recipes.DeleteOneAsync(recipeData);
//		}
//		catch
//		{
//			throw;
//		}
//	}

//}


