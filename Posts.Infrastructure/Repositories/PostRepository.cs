using System.Threading.Tasks;
using MongoDB.Driver;
using Posts.Infrastructure.Entities;

namespace Posts.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostDbContext _dbContext;

        public PostRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> GetById(string id)
        {
            return await _dbContext.Posts.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}