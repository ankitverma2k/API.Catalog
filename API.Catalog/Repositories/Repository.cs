
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
        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
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
