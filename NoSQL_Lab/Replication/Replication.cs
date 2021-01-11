using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoSQL_Lab
{
    class Replication
    {
        MongoCRUD mongo = new MongoCRUD("marchdb");

        public void replication()
        {
            mongo.DeleteAllRecords<RouterModel>("router");
            CountryModel country = new CountryModel { Name = "TestCountry" };
            CompanyModel company = new CompanyModel { Name = "TestCompany" };
            EncriptionModel encription = new EncriptionModel { Name = "TestEncription" };
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for(int i = 0; i < 1000; i++)
            {
                Insert(new RouterModel 
                { Name = "Test", 
                    Antennas = 4, 
                    Mac = "Test", 
                    Company = company, 
                    Country = country, 
                    Encription = encription 
                });
            }
            stopwatch.Stop();
            Console.WriteLine($"Insert time is {stopwatch.ElapsedMilliseconds}");
            stopwatch.Start();
            mongo.LoadRecords<RouterModel>("router");
            stopwatch.Stop();
            Console.WriteLine($"Select time is {stopwatch.ElapsedMilliseconds}");
        }

        public bool Insert(RouterModel router)
        {
            int retries = 3;

            while (retries > 0)
            {
                try
                {
                    return mongo.InsertRecord<RouterModel>("router", router);
                }
                catch (Exception e)
                {
                    retries--;
                    Thread.Sleep(1000);
                }
            }
            Console.WriteLine("Error to insert document");
            return false;
        }
    }
}
