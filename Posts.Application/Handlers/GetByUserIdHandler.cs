using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Posts.Application.Queries;
using Posts.Infrastructure.Entities;
using Posts.Infrastructure.Repositories;

namespace Posts.Application.Handlers
{
    public class GetByUserIdHandler : IRequestHandler<GetByUserIdQuery, List<Post>>
    {
        private readonly IPostRepository _postRepository;

        public GetByUserIdHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var pageSize = 5;
            return await _postRepository.GetByUserId(request.UserId, request.PageIndex, pageSize);
        }
    }
}