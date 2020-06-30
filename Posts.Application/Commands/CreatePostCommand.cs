using System.Collections.Generic;
using MediatR;
using Posts.Application.Dtos;
using Posts.Application.Extensions;

namespace Posts.Application.Commands
{
    public class CreatePostCommand : IRequest<PostDto>
    {
        public UserDto User { get; }

        public string Text { get; }

        public List<PhotoDto> Photos { get; }

        public List<VideoDto> Videos { get; }

        public CreatePostCommand(UserDto user, string text, List<PhotoDto> photos, List<VideoDto> videos)
        {
            User = user;

            Text = text.Clear();

            Photos = photos;

            Videos = videos;
        }
    }
}