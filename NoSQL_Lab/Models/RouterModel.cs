using System;
using MongoDB.Bson.Serialization.Attributes;

namespace NoSQL_Lab
{
    public class RouterModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Antennas { get; set; }

        public string Mac { get; set; }

        public CompanyModel Company { get; set; }

        public CountryModel Country { get; set; }

        public EncriptionModel Encription { get; set; }
    }
}
