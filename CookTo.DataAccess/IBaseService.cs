namespace CookTo.DataAccess;

public interface IBaseService<TEntity> where TEntity : BaseDocument
{
    Task<List<TEntity>> GetAllAsync(CancellationToken token);

    Task<TEntity> GetByIdAsync(string id, CancellationToken token);

    Task CreateAsync(TEntity obj, CancellationToken token);

    Task UpdateAsync(TEntity obj, CancellationToken token);

    Task DeleteAsync(string id, CancellationToken token);
}
