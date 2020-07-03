using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Posts.Application.Commands;
using Posts.Application.Exceptions;
using Posts.Infrastructure.Entities;
using Posts.Infrastructure.Services;

namespace Posts.Application.Handlers
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, Unit>
    {
        private readonly IMapper _mapper;

        private readonly IPostService _postService;

        public DeletePostHandler(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;

            _postService = postService;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postService.GetById(request.Id, request.UserId);

            if (post == null)
            {
                throw new NotFoundException(nameof(Post));
            }

            await _postService.Delete(post.Id);

            return Unit.Value;
        }
    }
}