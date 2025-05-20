using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbService
{
    public interface IMongoDbRepositories<T> where T : IEntity
    {
        Task CreateAsync(T item);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(T item);
    }
}
