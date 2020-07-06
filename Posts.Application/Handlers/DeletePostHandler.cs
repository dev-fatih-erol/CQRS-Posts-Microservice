using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Posts.Application.Commands;
using Posts.Application.Exceptions;
using Posts.Infrastructure.Entities;
using Posts.Infrastructure.Services;

namespace Posts.Application.Handlers
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, Unit>
    {
        private readonly IPostService _postService;

        public DeletePostHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postService.Delete(request.Id, request.UserId);

            if (post == null)
            {
                throw new NotFoundException(nameof(Post));
            }

            return Unit.Value;
        }
    }
}