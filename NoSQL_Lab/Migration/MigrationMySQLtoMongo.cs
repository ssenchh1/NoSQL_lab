using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NoSQL_Lab
{
    public class MigrationMySQLtoMongo
    {
        private MongoCRUD mongo;
        private MYSQlDao dao;

        public MigrationMySQLtoMongo()
        {
            mongo = new MongoCRUD("marchdb");
            dao = new MYSQlDao();
        }

        public void MigrateCountry()
        {
            //get all countries from sql database
            var countries = dao.GetAllCountries();

            List<CountryModel> countryModels = new List<CountryModel>(countries.Count);

            //adding country models to list
            foreach (var country in countries)
            {
                var counModel = new CountryModel { Name = country.CountryName };
                countryModels.Add(counModel);
            }

            //inserting countries from list to mongo
            foreach (var coun in countryModels)
            {
                mongo.InsertRecord<CountryModel>("country", coun);
            }
        }

        public void MigrateCompany()
        {
            //get all compamies from sql database
            var companies = dao.GetAllCompanies();

            List<CompanyModel> companyModels = new List<CompanyModel>(companies.Count);

            //adding company models to list
            foreach (var comp in companies)
            {
                var compModel = new CompanyModel { Name = comp.Name };
                companyModels.Add(compModel);
            }

            //inserting companies from list to mongo
            foreach (var comp in companyModels)
            {
                mongo.InsertRecord<CompanyModel>("company", comp);
            }
        }

        public void MigrateEncryption()
        {
            //get all encriptions from sql database
            var encriptions = dao.GetAllEncryptions();

            List<EncriptionModel> encrModels = new List<EncriptionModel>(encriptions.Count);

            //adding encr models to list
            foreach (var encr in encriptions)
            {
                var encrModel = new EncriptionModel { Name = encr.EncryptionName };
                encrModels.Add(encrModel);
            }

            //inserting encr from list to mongo
            foreach (var enc in encrModels)
            {
                mongo.InsertRecord<EncriptionModel>("encryptiontype", enc);
            }
        }

        public void MigrateRouter()
        {
            //get all routers from sql database
            var routers = dao.GetAllRouters();

            List<RouterModel> routerModels = new List<RouterModel>(routers.Count);

            //adding routers models to list
            foreach (var router in routers)
            {
                var routModel = new RouterModel 
                { 
                    Name = router.Name,
                    Antennas = router.AntennaAmount,
                    Mac = router.MAC_Adress,
                    Company = new CompanyModel { Name = dao.GetCompanyById(router.CompanyName).Name},
                    Country = new CountryModel { Name = dao.GetCountryById(router.ManufacturerCountry).CountryName},
                    Encription = new EncriptionModel { Name = dao.GetEncrById(router.EncryptionType).EncryptionName}
                };
                routerModels.Add(routModel);
            }

            //inserting routers from list to mongo
            foreach (var rout in routerModels)
            {
                mongo.InsertRecord<RouterModel>("router", rout);
            }
        }
    }
}
