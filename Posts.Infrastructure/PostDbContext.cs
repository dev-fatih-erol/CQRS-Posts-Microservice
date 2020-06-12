using MongoDB.Driver;
using Posts.Infrastructure.Configurations;
using Posts.Infrastructure.Entities;

namespace Posts.Infrastructure
{
    public class PostDbContext
    {
        private readonly IMongoDatabase _database;

        public PostDbContext(IMongoConfiguration configuration)
        {
            var client = new MongoClient(configuration.ConnectionString);

            _database = client.GetDatabase(MongoUrl.Create(configuration.ConnectionString).DatabaseName);
        }

        public IMongoCollection<Post> Posts => _database.GetCollection<Post>(nameof(Post));
    }
}