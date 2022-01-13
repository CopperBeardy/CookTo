namespace CookTo.Client.Repositories
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<bool> DeleteAsync(int id);

		Task<IEnumerable<TEntity>> GetAllAsync();

		Task<TEntity> GetByIdAsync(int id);

		Task<TEntity> InsertAsync(TEntity entity);

		Task<TEntity> UpdateAsync(TEntity entityToUpdate);
	}
}