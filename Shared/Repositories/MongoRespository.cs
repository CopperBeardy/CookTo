using CookTo.Shared.Models;
using MongoDB.Driver;

namespace CookTo.Shared.Repositories;

public class MongoRepository<TEntity> where TEntity : BaseEntity
{
    private readonly CookToDbContext context;
    private IMongoCollection<TEntity> dbCollection;

    public MongoRepository(CookToDbContext cookToDbContext)
    {
        context = cookToDbContext;
        dbCollection = context.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    public async Task Delete(TEntity entity) => await dbCollection.DeleteOneAsync(e => e.Id.Equals(entity.Id));

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await dbCollection.Find(e => true).ToListAsync();

    public async Task<TEntity> GetByIdAsync(string id) => await dbCollection.Find(e => e.Id.Equals(id))
        .FirstOrDefaultAsync();

    public async Task Insert(TEntity entity) => await dbCollection.InsertOneAsync(entity);

    public async Task Update(TEntity entity) => await dbCollection.ReplaceOneAsync(e => e.Id.Equals(entity.Id), entity);
}
