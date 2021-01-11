using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL_Lab
{
    public class MigrationMongoToMySQL
    {
        private MongoCRUD mongo;
        private MYSQlDao dao;

        public MigrationMongoToMySQL()
        {
            mongo = new MongoCRUD("marchdb");
            dao = new MYSQlDao();
        }

        public void MigrateCountry()
        {
            //get all records from mongo
            var mongocountries = mongo.LoadRecords<CountryModel>("country");

            List<Country> countries = new List<Country>(mongocountries.Count);

            //adding countries to sql list
            foreach (var country in mongocountries)
            {
                var coun = new Country { CountryName = country.Name };
                countries.Add(coun);
            }

            foreach (var country in countries)
            {
                dao.CreateCountry(country.CountryName);
            }
        }

        public void MigrateCompany()
        {
            //get all records from mongo
            var mongocompanies = mongo.LoadRecords<CompanyModel>("company");

            List<Company> companies = new List<Company>(mongocompanies.Count);

            //adding companies to sql list
            foreach (var country in mongocompanies)
            {
                var comp = new Company { Name = country.Name };
                companies.Add(comp);
            }

            foreach (var company in companies)
            {
                dao.CreateCompany(company.Name);
            }
        }

        public void MigrateEncrypyion()
        {
            //get all records from mongo
            var mongoencriptions = mongo.LoadRecords<EncriptionModel>("encryptiontype");

            List<EncriptionType> encriptions = new List<EncriptionType>(mongoencriptions.Count);

            //adding companies to sql list
            foreach (var encription in mongoencriptions)
            {
                var encr = new EncriptionType { EncryptionName = encription.Name };
                encriptions.Add(encr);
            }

            foreach (var encript in encriptions)
            {
                dao.CreateEncryption(encript.EncryptionName);
            }
        }

        public void MigrateRouter()
        {
            //get all records from mongo
            var mongorouters = mongo.LoadRecords<RouterModel>("router");

            List<Router> routers = new List<Router>(mongorouters.Count);

            //adding companies to sql list
            foreach (var router in mongorouters)
            {
                var rout = new Router 
                ( 
                    router.Name,
                    dao.GetCompanyByName(router.Company.Name).Id,
                    router.Antennas, 
                    router.Mac,
                    dao.GetCompanyByName(router.Country.Name).Id,
                    dao.GetEncriptionByName(router.Encription.Name).Id 
                );
                routers.Add(rout);
            }

            foreach (var router in routers)
            {
                dao.CreateRouter(router);
            }
        }

    }
}
