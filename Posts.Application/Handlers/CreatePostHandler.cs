using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Posts.Application.Commands;
using Posts.Application.Dtos;
using Posts.Infrastructure.Entities;
using Posts.Infrastructure.Services;

namespace Posts.Application.Handlers
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, PostDto>
    {
        private readonly IMapper _mapper;

        private readonly IPostService _postService;

        public CreatePostHandler(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;

            _postService = postService;
        }

        public async Task<PostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post();
            var user = _mapper.Map<User>(request.User);
            post.User = user;
            post.Text = post.Text;
            var photos = _mapper.Map<List<Photo>>(request.Photos);
            post.Photos = photos;
            var videos = _mapper.Map<List<Video>>(request.Videos);
            post.Videos = videos;
            post.CreatedDate = DateTime.UtcNow;

            await _postService.Create(post);

            var response = _mapper.Map<PostDto>(post);

            return response;
        }
    }
}