using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL_Lab
{
    class Aggregation
    {
        MongoCRUD mongo = new MongoCRUD("marchdb");

        public void TestAggregation()
        {
            Stopwatch stopwatch = new Stopwatch();
            //Query 1 no aggregation
            Console.WriteLine("Query 1 no aggregation");

            stopwatch.Start();
            var routerlist = mongo.LoadCollection<RouterModel>("router").Find(new BsonDocument("Antennas", 8)).ToList<RouterModel>();
            stopwatch.Stop();
            foreach (var router in routerlist)
            {
                Console.WriteLine($"{router.Id}: {router.Antennas}, {router.Name}");
                Console.WriteLine($"query time no aggregation is {stopwatch.ElapsedMilliseconds}");
                Console.WriteLine();
            }
            //Query 1 Aggregation
            Console.WriteLine("Query 1 Aggregation");
            stopwatch.Start();

            var match = new BsonDocument 
            { 
                { 
                    "$match", new BsonDocument 
                    { 
                        {"Antennas", new BsonDocument
                        {
                            {"$eq", 8 }
                        } 
                        } 
                    } 
                } 
            };

            var pipeline = new[] { match }; 
            var routerlist2 = mongo.LoadCollection<RouterModel>("router").Aggregate<RouterModel>(pipeline).ToList<RouterModel>();
            stopwatch.Stop();
            foreach (var router in routerlist2)
            {
                Console.WriteLine($"{router.Id}: {router.Antennas}, {router.Name}");
                Console.WriteLine($"time with aggregation is {stopwatch.ElapsedMilliseconds}");
                Console.WriteLine();
            }



            //Query 2 no aggregation
            Console.WriteLine("Query 2 no aggregation");

            stopwatch.Start();

            var routerlist3 = mongo.LoadCollection<RouterModel>("router").Find(new BsonDocument("Name", "first")).ToList<RouterModel>();
            stopwatch.Stop();
            foreach (var router in routerlist3)
            {
                Console.WriteLine($"{router.Id}: {router.Antennas}, {router.Name}");
                Console.WriteLine($"query2 time no aggregation is {stopwatch.ElapsedMilliseconds}");
                Console.WriteLine();
            }

            //Query 2 Aggregation
            Console.WriteLine("Query 2 Aggregation");

            stopwatch.Start();

            var match1 = new BsonDocument
            {
                {
                    "$match", new BsonDocument
                    {
                        {"Name", "first"}
                    }
                }
            };

            var pipeline1 = new[] { match1 };
            var routerlist4 = mongo.LoadCollection<RouterModel>("router").Aggregate<RouterModel>(pipeline1).ToList<RouterModel>();
            stopwatch.Stop();
            foreach (var router in routerlist4)
            {
                Console.WriteLine($"{router.Id}: {router.Antennas}, {router.Name}");
                Console.WriteLine($"query2 time with aggregation is {stopwatch.ElapsedMilliseconds}");
                Console.WriteLine();
            }


            //Query 3 no aggregation
            Console.WriteLine("Query 3 no aggregation");
            stopwatch.Start();
            var filter = new BsonDocument("$and", new BsonArray{

                new BsonDocument("Antennas",new BsonDocument("eq", 2)),
                new BsonDocument("Name", "first")
            });
            var routerlist5 = mongo.LoadCollection<RouterModel>("router").Find(filter).ToList<RouterModel>();
            stopwatch.Stop();
            foreach (var router in routerlist5)
            {
                Console.WriteLine($"{router.Id}: {router.Antennas}, {router.Name}");
                Console.WriteLine($"query3 time no aggregation is {stopwatch.ElapsedMilliseconds}");
                Console.WriteLine();
            }

            //Query 3 Aggregation
            Console.WriteLine("Query 3 Aggregation");
            stopwatch.Start();

            var newmatch = new BsonDocument
            {
                {
                    "$match", new BsonDocument
                    {
                        {"Antennas", new BsonDocument
                        {
                            {"$eq", 8 }
                        }
                        }
                    }
                }
            };
            var newmatch1 = new BsonDocument
            {
                {
                    "$match", new BsonDocument
                    {
                        {"Name", "first"}
                    }
                }
            };
            var pipeline2 = new[] { match1 };
            var routerlist6 = mongo.LoadCollection<RouterModel>("router").Aggregate<RouterModel>(pipeline2).ToList<RouterModel>();
            stopwatch.Stop();
            foreach (var router in routerlist6)
            {
                Console.WriteLine($"{router.Id}: {router.Antennas}, {router.Name}");
                Console.WriteLine($"query3 time with aggregation is {stopwatch.ElapsedMilliseconds}");
                Console.WriteLine();
            }
            stopwatch.Stop();
        }
    }
}
