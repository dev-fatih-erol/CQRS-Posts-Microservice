using System.Threading.Tasks;
using Posts.Infrastructure.Entities;

namespace Posts.Infrastructure.Repositories
{
    public interface IPostRepository
    {
        Task<Post> GetById(string id);
    }
}