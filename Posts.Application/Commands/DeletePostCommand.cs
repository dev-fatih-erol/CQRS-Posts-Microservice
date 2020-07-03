using MediatR;

namespace Posts.Application.Commands
{
    public class DeletePostCommand : IRequest<Unit>
    {
        public string Id { get; }

        public int UserId { get; }

        public DeletePostCommand(string id, int userId)
        {
            Id = id;

            UserId = userId;
        }
    }
}