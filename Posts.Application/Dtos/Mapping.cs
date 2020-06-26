using AutoMapper;
using Posts.Infrastructure.Entities;

namespace Posts.Application.Dtos
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Post, PostDto>();

            CreateMap<User, UserDto>();

            CreateMap<Photo, PhotoDto>();

            CreateMap<Video, VideoDto>();
        }
    }
}