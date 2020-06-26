using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Posts.Application.Dtos;
using Posts.Application.Queries;
using Posts.Infrastructure.Services;

namespace Posts.Application.Handlers
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, PostDto>
    {
        private readonly IMapper _mapper;

        private readonly IPostService _postService;

        public GetPostByIdHandler(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;

            _postService = postService;
        }

        public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _postService.GetById(request.Id);

            var response = _mapper.Map<PostDto>(post);

            return response;
        }
    }
}