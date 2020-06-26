using MediatR;
using Posts.Application.Dtos;

namespace Posts.Application.Queries
{
    public class GetPostByUserIdQuery : IRequest<PaginatedListDto<PostDto>>
    {
        public int UserId { get; }

        public int PageIndex { get; }

        public GetPostByUserIdQuery(int userId, int pageIndex)
        {
            UserId = userId;

            PageIndex = pageIndex < 1 ? 1 : pageIndex;
        }
    }
}