using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Posts.Application.Queries;
using Posts.Infrastructure.Entities;
using Posts.Infrastructure.Services;

namespace Posts.Application.Handlers
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, Post>
    {
        private readonly IPostService _postService;

        public GetPostByIdHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            return await _postService.GetById(request.Id);
        }
    }
}