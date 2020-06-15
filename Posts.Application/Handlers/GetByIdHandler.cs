using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Posts.Application.Queries;
using Posts.Infrastructure.Entities;
using Posts.Infrastructure.Services;

namespace Posts.Application.Handlers
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, Post>
    {
        private readonly IPostService _postService;

        public GetByIdHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<Post> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _postService.GetById(request.Id);
        }
    }
}