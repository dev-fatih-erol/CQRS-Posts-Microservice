using System;
using System.Collections.Generic;

namespace Posts.Application.Dtos
{
    public class PostDto
    {
        public string Id { get; set; }

        public UserDto User { get; set; }

        public string Text { get; set; }

        public List<PhotoDto> Photos { get; set; }

        public List<VideoDto> Videos { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}