using System;
using MongoDB.Bson.Serialization.Attributes;

namespace NoSQL_Lab
{
    public class CompanyModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
