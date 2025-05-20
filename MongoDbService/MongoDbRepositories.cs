using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbService
{
    public class MongoDbRepositories<T> : IMongoDbRepositories<T> where T : IEntity
    {
        private readonly IMongoCollection<T>? dbCollections;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public MongoDbRepositories(IMongoDatabase database, string mongoDbCollectionName)
        {
            dbCollections = database.GetCollection<T>(mongoDbCollectionName);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await dbCollections.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(e => e.Id, id);

            return await dbCollections.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));

            }
            await dbCollections.InsertOneAsync(item);
        }

        public async Task UpdateAsync(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            FilterDefinition<T> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, item.Id);
            await dbCollections.ReplaceOneAsync(filter, item);
        }

        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, id);
            await dbCollections.DeleteOneAsync(filter);

        }

    }
}
