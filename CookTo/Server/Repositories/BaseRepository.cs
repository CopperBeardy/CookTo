using CookTo.Server.DbContext;
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

	public virtual async Task<List<TEntity>> GetAllAsync()
	{
		var docs = await _dbCollection.FindAsync(e => true);
		var result = await docs.ToListAsync();
		if (result.Count() == 0)
		{
			throw new Exception($"no documents found ");
		}
		return result;
	}

	public virtual async Task<TEntity> GetByIdAsync(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			throw new ArgumentNullException(nameof(id));
		}
		var docs = await _dbCollection.FindAsync(e => e.GetId().Equals(id));
		 var result = await docs.FirstOrDefaultAsync();
		if (result == null)
		{
			throw new Exception($"unable to find document with Id : {id}");
		}
		return result;
	}

	public virtual async Task CreateAsync(TEntity obj)
	{
		if(obj == null)
		{
			throw new ArgumentNullException(nameof(obj));
		}
		await _dbCollection.InsertOneAsync(obj);
	}

	public virtual async Task UpdateAsync(TEntity obj)
	{
		if (obj == null)
		{
			throw new ArgumentNullException(nameof(obj));
		}
		await _dbCollection.ReplaceOneAsync(
						e => e.GetId().Equals(obj.GetId()), obj);
	}

	public async Task<DeleteResult> DeleteAsync(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			throw new ArgumentNullException(nameof(id));
		}
		return await _dbCollection.DeleteOneAsync(e => e.GetId().Equals(id));
	}

}
