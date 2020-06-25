﻿using MediatR;
using Posts.Infrastructure.Entities;

namespace Posts.Application.Queries
{
    public class GetPostByIdQuery : IRequest<Post>
    {
        public string Id { get; }

        public GetPostByIdQuery(string id)
        {
            Id = id;
        }
    }
}