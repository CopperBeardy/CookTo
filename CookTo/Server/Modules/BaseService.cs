namespace CookTo.Server.Modules;

public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseDocument
{
    protected readonly ICookToDbContext dbContext;

    protected IMongoCollection<TEntity> DbCollection { get; set; }


    public BaseService(ICookToDbContext dbContext)
    {
        this.dbContext = dbContext;
        DbCollection = this.dbContext.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken token) => await DbCollection.Find(e => true)
        .ToListAsync();


    public virtual async Task<TEntity> GetByIdAsync(string id, CancellationToken token) => await DbCollection.Find(
        e => e.Id.Equals(id))
        .FirstOrDefaultAsync();


    public virtual async Task CreateAsync(TEntity obj, CancellationToken token)
    { await DbCollection.InsertOneAsync(obj); }

    public virtual async Task UpdateAsync(TEntity obj, CancellationToken token) => await DbCollection.ReplaceOneAsync(e => e.Id
        .Equals(obj.Id), obj);

    public virtual async Task DeleteAsync(string id, CancellationToken token) => await DbCollection.DeleteOneAsync(e => e.Id
        .Equals(id));
}
