using API.Catalog.Models;
using MongoDbService;

namespace API.Catalog.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task Delete(string id);
        Task<T?> GetById(string id);
        Task<IEnumerable<T>> GetAll();
        Task Insert(T item);
        Task Update(T item);
    }
}
