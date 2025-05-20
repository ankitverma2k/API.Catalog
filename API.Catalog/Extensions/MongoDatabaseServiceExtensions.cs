using API.Catalog.Models;
using API.Catalog.Settings;
using MongoDB.Driver;
using MongoDbService;

namespace API.Catalog.Extensions
{
    public static class MongoDatabaseServiceExtensions
    {
        public static IConfiguration? Configuration { get; set; }

        static ServiceSettings? settings;
        public static void ConfigureMongoDbServices(this IConfiguration configuration)
        {
            Configuration = configuration;
            settings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
        }


        public static void ConfigureMongoDbMiddleware(this IServiceCollection services)
        {
            services.AddSingleton(servicesProvider =>
            {
                var mongoDBSettings = Configuration?.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                var mongoClient = new MongoClient(mongoDBSettings?.ConnectionString());
                return mongoClient.GetDatabase(settings?.ServiceName);
            });


            services.AddSingleton<IMongoDbRepositories<Category>>(serviceProvider =>
            {
                var database = serviceProvider.GetService<IMongoDatabase>();
                if (database == null)
                {

                    throw new InvalidOperationException("Unable to connect Mongo DB");
                }
                else
                {
                    return new MongoDbRepositories<Category>(database, "items");
                }

            });
        }
    }
}
