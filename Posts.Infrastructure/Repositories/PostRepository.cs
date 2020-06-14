using System.Collections.Generic;
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

        public async Task<List<Post>> GetByUserId(int userId, int skip, int limit)
        {
            return await _dbContext.Posts
                .Find(p => p.User.Id == userId)
                .SortByDescending(p => p.CreatedDate)
                .Skip((skip - 1) * limit)
                .Limit(limit)
                .ToListAsync();
        }

        public async Task<Post> GetById(string id)
        {
            return await _dbContext.Posts.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}