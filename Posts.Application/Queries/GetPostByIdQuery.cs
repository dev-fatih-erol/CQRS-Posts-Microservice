using MediatR;
using Posts.Application.Dtos;

namespace Posts.Application.Queries
{
    public class GetPostByIdQuery : IRequest<PostDto>
    {
        public string Id { get; }

        public GetPostByIdQuery(string id)
        {
            Id = id;
        }
    }
}