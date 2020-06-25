using System.Collections.Generic;
using MediatR;
using Posts.Infrastructure.Entities;

namespace Posts.Application.Queries
{
    public class GetPostByUserIdQuery : IRequest<List<Post>>
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