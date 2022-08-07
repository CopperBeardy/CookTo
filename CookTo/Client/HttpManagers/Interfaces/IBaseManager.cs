namespace CookTo.Client.HTTPManagers.Interfaces;

public interface IBaseManager<T>
{
    Task<IList<T>> GetAll();

    Task<T?> GetById(string id);

    Task<T?> Insert(T entity);

    Task<bool> Update(T entityToUpdate);
}

