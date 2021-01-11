using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace NoSQL_Lab
{
    public class MongoCRUD : IMyDao
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            //var client = new MongoClient("mongodb://localhost:28018,localhost:27019,localhost:27020/?replicaSet=myreplica&retryWrites=true");
            var client = new MongoClient();

            db = client.GetDatabase(database);
        }

        public bool InsertRecord<T>(string table, T record)
        {
            try
            {
                var collection = db.GetCollection<T>(table);
                collection.InsertOne(record);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public IMongoCollection<T> LoadCollection<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection;
        }

        public T LoadRecordById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).First();
        }

        public void UpsertRecord<T>(string table, Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);
            var result = collection.ReplaceOne(new BsonDocument("_id", id), record, new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }

        public void DeleteAllRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Empty;
            collection.DeleteMany(filter);
        }
    }
}
