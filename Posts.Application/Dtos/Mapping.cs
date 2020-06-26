using AutoMapper;
using Posts.Application.Helpers;
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

            CreateMap<PaginatedList<Post>, PaginatedListDto<PostDto>>()
                .ForMember(d => d.PageIndex, s => s.MapFrom(s => s.PageIndex))
                .ForMember(d => d.TotalPages, s => s.MapFrom(s => s.TotalPages))
                .ForMember(d => d.HasPreviousPage, s => s.MapFrom(s => s.HasPreviousPage))
                .ForMember(d => d.HasNextPage, s => s.MapFrom(s => s.HasNextPage))
                .ForMember(d => d.Data, s => s.MapFrom(s => s));
        }
    }
}