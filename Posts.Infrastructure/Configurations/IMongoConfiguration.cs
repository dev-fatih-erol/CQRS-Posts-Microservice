namespace Posts.Infrastructure.Configurations
{
    public interface IMongoConfiguration
    {
        string ConnectionString { get; set; }
    }
}