namespace CookTo.Server.Services.Interfaces;

public interface IBaseService<TEntity> where TEntity : BaseEntity
{
	Task<List<TEntity>> GetAllAsync();
	Task<TEntity> GetByIdAsync(string id);
	Task CreateAsync(TEntity obj);
	Task UpdateAsync(TEntity obj);
	Task DeleteAsync(string id);
}
