using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Posts.Infrastructure.Entities;

namespace Posts.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly PostDbContext _dbContext;

        public PostService(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IMongoQueryable<Post> GetByUserId(int userId)
        {
            return _dbContext.Posts.AsQueryable().Where(p => p.User.Id == userId);
        }

        public async Task<Post> GetById(string id, int userId)
        {
            return await _dbContext.Posts.Find(p => p.Id == id && p.User.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<Post> GetById(string id)
        {
            return await _dbContext.Posts.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task Delete(string id)
        {
            await _dbContext.Posts.DeleteOneAsync(p => p.Id == id);
        }

        public async Task Create(Post post)
        {
            await _dbContext.Posts.InsertOneAsync(post);
        }
    }
}