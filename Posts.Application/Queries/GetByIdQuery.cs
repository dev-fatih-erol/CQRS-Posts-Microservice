using MediatR;
using Posts.Infrastructure.Entities;

namespace Posts.Application.Queries
{
    public class GetByIdQuery : IRequest<Post>
    {
        public string Id { get; }

        public GetByIdQuery(string id)
        {
            Id = id;
        }
    }
}