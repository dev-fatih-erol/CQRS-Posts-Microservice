using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Posts.Application.Queries;
using Posts.Infrastructure.Entities;
using Posts.Infrastructure.Repositories;

namespace Posts.Application.Handlers
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, Post>
    {
        private readonly IPostRepository _postRepository;

        public GetByIdHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetById(request.Id);
        }
    }
}