using CookTo.Server.Documents;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseDocument
{
    protected readonly ICookToDbContext dbContext;

    protected IMongoCollection<TEntity> dbCollection { get; set; }


    public BaseService(ICookToDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbCollection = this.dbContext.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken token) => await dbCollection.Find(e => true)
        .ToListAsync();

    public virtual async Task<TEntity> GetByIdAsync(string id, CancellationToken token) => await dbCollection.Find(
        e => e.Id.Equals(id))
        .FirstOrDefaultAsync();

    public virtual async Task CreateAsync(TEntity obj, CancellationToken token)
    { await dbCollection.InsertOneAsync(obj); }

    public virtual async Task UpdateAsync(TEntity obj, CancellationToken token) => await dbCollection.ReplaceOneAsync(
        e => e.Id.Equals(obj.Id),
        obj);

    public virtual async Task DeleteAsync(string id, CancellationToken token) => await dbCollection.DeleteOneAsync(
        e => e.Id.Equals(id));
}
