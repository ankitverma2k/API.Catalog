
using API.Catalog.Models;
using MongoDbService;

namespace API.Catalog.Repositories
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        IMongoDbRepositories<T> _mongoDbRepositories;
        public Repository(IMongoDbRepositories<T> mongoDbRepositories)
        {
            _mongoDbRepositories = mongoDbRepositories;
        }
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetById(Guid id)
        {
            return (await _mongoDbRepositories.GetByIdAsync(id));
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return (await _mongoDbRepositories.GetAllAsync());
        }

        public Task Insert(T item)
        {
            return _mongoDbRepositories.CreateAsync(item);
        }

        public Task Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
