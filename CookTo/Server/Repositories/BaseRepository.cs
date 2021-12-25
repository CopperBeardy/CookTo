using CookTo.Server.DbContext;
using MongoDB.Bson;
using MongoDB.Driver;
using ServiceStack;

namespace CookTo.Server.Repositories;
public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
	protected readonly ICookToDbContext _dbContext;
	protected IMongoCollection<TEntity> _dbCollection { get; set; }
	public BaseRepository(ICookToDbContext dbContext)
	{
		_dbContext = dbContext;
		_dbCollection = _dbContext.GetCollection<TEntity>(typeof(TEntity).Name);
	}

	public async Task<List<TEntity>> GetAllAsync()
	{
		try
		{
			var filter = Builders<TEntity>.Filter.Empty;
			var all = await _dbCollection.FindAsync(filter);
			var result = await all.ToListAsync();
			if(result.Count == 0)
			{
				result = new List<TEntity>();
			}
			return result;
		}
		catch (Exception)
		{

			throw;
		}
	}
		public async Task<TEntity> GetByIdAsync(string id)
		{
			try
			{
				var oid = new ObjectId(id);
				FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", oid);
				return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

	public async Task CreateAsync(TEntity obj)
	{
		try
		{
			await _dbCollection.InsertOneAsync(obj);
		}
		catch
		{
			throw;
		}
	}



	public virtual async Task UpdateAsync(TEntity obj)
	{
		try
		{
			await _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()),obj);
		}
		catch
		{
			throw;
		}
	}
	public  async Task<DeleteResult> DeleteAsync(string id)
	{
		try
		{
			var oid = new ObjectId(id);
			FilterDefinition<TEntity> data = Builders<TEntity>.Filter.Eq("Id", oid);
			return await _dbCollection.DeleteOneAsync(data);
			
		}
		catch(Exception ex)
		{
			throw new Exception(ex.ToString());
		}
	}

}
