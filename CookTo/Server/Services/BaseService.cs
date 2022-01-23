using CookTo.Server.Services.Interfaces;
using MongoDB.Bson;

namespace CookTo.Server.Services;

public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
{
    protected readonly ICookToDbContext dbContext;

    protected IMongoCollection<TEntity> dbCollection { get; set; }


    public BaseService(ICookToDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbCollection = this.dbContext.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    public virtual async Task<List<TEntity>> GetAllAsync() => await dbCollection.Find(e => true).ToListAsync();

    public virtual async Task<TEntity> GetByIdAsync(string id) => await dbCollection.Find(e => e.Id.Equals(id))
        .FirstOrDefaultAsync();

    public virtual async Task CreateAsync(TEntity obj) { await dbCollection.InsertOneAsync(obj); }

    public virtual async Task UpdateAsync(TEntity obj) => await dbCollection.ReplaceOneAsync(
        e => e.Id.Equals(obj.Id),
        obj);

    public virtual async Task DeleteAsync(string id) => await dbCollection.DeleteOneAsync(
        e => e.Id.Equals(new ObjectId(id)));
}
