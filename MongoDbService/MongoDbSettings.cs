namespace API.Catalog.Settings
{
    public class MongoDbSettings
    {
        public required string Host { get; set; }

        public required string Port { get; set; }

        public required string Password { get; set; }

        public string ConnectionString() => $"{Host}://{Port}:{Password}@cluster0.addwwlk.mongodb.net/";
    }
}
