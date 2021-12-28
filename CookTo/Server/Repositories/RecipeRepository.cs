using CookTo.Server.DbContext;
using CookTo.Server.Repositories;
using CookTo.Shared.Enums;
using CookTo.Shared.Models;
using MongoDB.Driver;

namespace CookTo.Server.Repositories;
public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{

	public RecipeRepository(ICookToDbContext dbContext) : base(dbContext)
	{

	}

	public async Task<List<RecipeThumbnail>> GetAllThumbnailsByCategoryAsync(Category category)
	{
		var recipeProject = Builders<Recipe>.Projection
		.Include(r => r.Id)
		.Include(r => r.ImageUrl)
		.Include(r => r.Title)
		.Include(r => r.Category);
		return await _dbCollection
			.Aggregate()
			.Match(c => c.Category.Equals(Enum.GetName(category)))
			.Project<RecipeThumbnail>(recipeProject)
			.ToListAsync();
	}
	public async Task CreateRecipeAsync(Recipe recipe)
	{

	}

}


