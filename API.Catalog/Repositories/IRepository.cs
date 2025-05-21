using API.Catalog.Models;
using MongoDbService;

namespace API.Catalog.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task Delete(Guid id);
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Insert(T item);
        Task Update(T item);
    }
}
