using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver.Linq;
using Posts.Application.Helpers;
using Posts.Application.Queries;
using Posts.Infrastructure.Entities;
using Posts.Infrastructure.Services;

namespace Posts.Application.Handlers
{
    public class GetPostByUserIdHandler : IRequestHandler<GetPostByUserIdQuery, List<Post>>
    {
        private readonly IPostService _postService;

        public GetPostByUserIdHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<List<Post>> Handle(GetPostByUserIdQuery request, CancellationToken cancellationToken)
        {
            var query = _postService.GetByUserId(request.UserId);
            var posts = from p in query
                        orderby p.CreatedDate descending
                        select p;

            var pageSize = 5;
            var paginatedPosts = await PaginatedList<Post>.CreateAsync(posts, request.PageIndex, pageSize);

            return paginatedPosts;
        }
    }
}