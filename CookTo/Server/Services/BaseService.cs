using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;
public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
{
	protected readonly ICookToDbContext _dbContext;
	protected IMongoCollection<TEntity> _dbCollection { get; set; }


	public BaseService(ICookToDbContext dbContext)
	{
		_dbContext = dbContext;
		_dbCollection = _dbContext.GetCollection<TEntity>(typeof(TEntity).Name);
	}

	public virtual async Task<List<TEntity>> GetAllAsync() => await _dbCollection.Find(e => true).ToListAsync();

	public virtual async Task<TEntity> GetByIdAsync(string id) => await _dbCollection.Find(e => e.Id.Equals(id)).FirstOrDefaultAsync();

	public virtual async Task CreateAsync(TEntity obj) => await _dbCollection.InsertOneAsync(obj);

	public virtual async Task UpdateAsync(TEntity obj) => await _dbCollection.ReplaceOneAsync( e => e.Id.Equals(obj.Id), obj);

	public virtual async Task DeleteAsync(string id) => await _dbCollection.DeleteOneAsync(e => e.Id.Equals(id));

}
