using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver.Linq;
using Posts.Application.Dtos;
using Posts.Application.Helpers;
using Posts.Application.Queries;
using Posts.Infrastructure.Entities;
using Posts.Infrastructure.Services;

namespace Posts.Application.Handlers
{
    public class GetPostByUserIdHandler : IRequestHandler<GetPostByUserIdQuery, PaginatedListDto<PostDto>>
    {
        private readonly IMapper _mapper;

        private readonly IPostService _postService;

        public GetPostByUserIdHandler(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;

            _postService = postService;
        }

        public async Task<PaginatedListDto<PostDto>> Handle(GetPostByUserIdQuery request, CancellationToken cancellationToken)
        {
            var query = _postService.GetByUserId(request.UserId);
            var posts = from p in query
                        orderby p.CreatedDate descending
                        select p;

            var pageSize = 5;
            var paginatedPosts = await PaginatedList<Post>.CreateAsync(posts, request.PageIndex, pageSize);

            var response = _mapper.Map<PaginatedListDto<PostDto>>(paginatedPosts);

            return response;
        }
    }
}