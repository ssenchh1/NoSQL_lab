using System.Text;
using System.Threading.Tasks;

namespace NoSQL_Lab
{

    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("marchdb");

            //RouterModel router = new RouterModel
            //{
            //    Name = "Third Good Router",
            //    Antennas = 8,
            //    Mac = "1235448/9",
            //    Company = new CompanyModel
            //    {
            //        Name = "ASUS"
            //    },
            //    Country = new CountryModel
            //    {
            //        Name = "China"
            //    },
            //    Encription = new EncriptionModel
            //    {
            //        Name = "WPA3"
            //    }
            //};

            //db.InsertRecord("router", router);

            //var recs = db.LoadRecords<RouterModel>("router");

            //foreach (var rec in recs)
            //{
            //    Console.WriteLine($"{rec.Id} : {rec.Name}, {rec.Antennas}, {rec.Mac}, {rec.Company?.Name}, {rec.Country?.Name}, {rec.Encription?.Name}");
            //    Console.WriteLine();
            //}

            //string[] names = new string[] { "China", "Korea", "Vietnam" };

            //for (int i = 0; i < 3; i++)
            //{
            //    var country = new CountryModel { Name = names[i] };
            //    db.InsertRecord<CountryModel>("country", country);
            //}


            //var recs = db.LoadRecords<CountryModel>("country");

            //foreach (var rec in recs)
            //{
            //    Console.WriteLine($"{rec.Id} : {rec.Name}");
            //    Console.WriteLine();
            //}


            //string[] compnames = new string[] { "Sasun", "Mikrotk", "Asus", "Tedda" };

            //for (int i = 0; i < 4; i++)
            //{
            //    var comp = new CompanyModel { Name = compnames[i] };
            //    db.InsertRecord<CompanyModel>("company", comp);
            //}


            //var recs = db.LoadRecords<CompanyModel>("company");

            //foreach (var rec in recs)
            //{
            //    Console.WriteLine($"{rec.Id} : {rec.Name}");
            //    Console.WriteLine();
            //}


            //string[] encrnames = new string[] { "WAP", "WPA", "WPA2", "WPA3" };

            //for (int i = 0; i < 4; i++)
            //{
            //    var comp = new EncriptionModel { Name = encrnames[i] };
            //    db.InsertRecord<EncriptionModel>("encryptiontype", comp);
            //}


            //var recs = db.LoadRecords<EncriptionModel>("encryptiontype");

            //foreach (var rec in recs)
            //{
            //    Console.WriteLine($"{rec.Id} : {rec.Name}");
            //    Console.WriteLine();
            //}

            //var onerec = db.LoadRecordById<RouterModel>("router", new Guid("99c68fa1-6ae0-4286-b6ad-a5eefd22a5fa"));

            //MigrationMySQLtoMongo migration = new MigrationMySQLtoMongo();
            //migration.MigrateCountry();
            //migration.MigrateCompany();
            //migration.MigrateEncryption();
            //migration.MigrateRouter();

            //Replication MongoRelication = new Replication();
            //MongoRelication.replication();


            //CountryModel country = new CountryModel { Name = "TestCountry" };
            //CompanyModel company = new CompanyModel { Name = "TestCompany" };
            //EncriptionModel encription = new EncriptionModel { Name = "TestEncr" };
            //for (int i = 0; i < 50000; i++)
            //{
            //    db.InsertRecord<RouterModel>("router",new RouterModel
            //    {
            //        Name = "Test",
            //        Antennas = 4,
            //        Mac = "Test",
            //        Company = company,
            //        Country = country,
            //        Encription = encription
            //    });
            //    Console.WriteLine("inserted");
            //}

            Aggregation aggregation = new Aggregation();
            aggregation.TestAggregation();
        }
    }
}
