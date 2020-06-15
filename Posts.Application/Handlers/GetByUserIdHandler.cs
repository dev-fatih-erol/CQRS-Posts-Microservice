using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Posts.Application.Queries;
using Posts.Infrastructure.Entities;
using Posts.Infrastructure.Services;

namespace Posts.Application.Handlers
{
    public class GetByUserIdHandler : IRequestHandler<GetByUserIdQuery, List<Post>>
    {
        private readonly IPostService _postService;

        public GetByUserIdHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<List<Post>> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var pageSize = 5;
            return await _postService.GetByUserId(request.UserId, request.PageIndex, pageSize);
        }
    }
}