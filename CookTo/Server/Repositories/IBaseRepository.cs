using MongoDB.Driver;

namespace CookTo.Server.Repositories;

public interface IBaseRepository<TEntity>where TEntity : class
{
	Task<List<TEntity>> GetAllAsync();
	Task<TEntity> GetByIdAsync(string id);
	Task CreateAsync(TEntity obj);
	Task UpdateAsync(TEntity obj);
	Task<DeleteResult> DeleteAsync(string id);
}
