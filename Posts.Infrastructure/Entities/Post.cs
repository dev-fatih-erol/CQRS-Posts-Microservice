using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Posts.Infrastructure.Entities
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public User User { get; set; }

        [BsonIgnoreIfNull]
        public string Text { get; set; }

        [BsonIgnoreIfNull]
        public List<Photo> Photos { get; set; }

        [BsonIgnoreIfNull]
        public List<Video> Videos { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}