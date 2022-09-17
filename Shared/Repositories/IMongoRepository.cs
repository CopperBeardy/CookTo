using CookTo.Shared.Models;

namespace CookTo.Shared.Repositories;

public interface IMongoRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(string id);

    Task<TEntity> Insert(TEntity entity);

    Task<TEntity> Update(TEntity entity);

    Task<bool> Delete(TEntity entity);
}
