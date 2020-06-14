using System.Collections.Generic;
using System.Threading.Tasks;
using Posts.Infrastructure.Entities;

namespace Posts.Infrastructure.Repositories
{
    public interface IPostRepository
    {
        Task<List<Post>> GetByUserId(int userId, int skip, int limit);

        Task<Post> GetById(string id);
    }
}