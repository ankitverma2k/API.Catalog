using API.Catalog;
using API.Catalog.Extensions;
using API.Catalog.Models;
using API.Catalog.Repositories;
using API.Catalog.Services;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(MongoDB.Bson.BsonType.DateTime));

builder.Configuration.ConfigureMongoDbServices();


builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<IRepository<Category>,Repository<Category>>();
builder.Services.ConfigureMongoDbMiddleware();


var app = builder.Build();

app.UseHttpsRedirection();

app.CategoryApiConfiguation();

app.Run();

