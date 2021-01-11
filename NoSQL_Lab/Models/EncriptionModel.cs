using System;
using MongoDB.Bson.Serialization.Attributes;

namespace NoSQL_Lab
{
    public class EncriptionModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
