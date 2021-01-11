using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace NoSQL_Lab
{
    public class MYSQlDao : IMyDao
    {
        public List<Company> GetAllCompanies()
        {
            List<Company> list = new List<Company>();

            string sqlexpression = "SELECT * FROM Company";
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                object[] obj = new object[reader.FieldCount];
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        var quantity = reader.GetValues(obj);
                        list.Add(new Company(obj));
                        Console.WriteLine($"{id}\t{name}");
                    }
                }
                reader.Close();
            }
            return list;
        }

        public List<Country> GetAllCountries()
        {
            List<Country> list = new List<Country>();

            string sqlexpression = "SELECT * FROM manufacturercountry";
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                object[] obj = new object[reader.FieldCount];
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        list.Add(new Country((int)id, (string)name));
                    }
                }
                reader.Close();
            }
            return list;
        }

        public List<EncriptionType> GetAllEncryptions()
        {
            List<EncriptionType> list = new List<EncriptionType>();

            string sqlexpression = "SELECT * FROM encryptiontype";
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                object[] obj = new object[reader.FieldCount];
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        list.Add(new EncriptionType((int)id, (string)name));
                    }
                }
                reader.Close();
            }
            return list;
        }

        public List<Router> GetAllRouters()
        {
            List<Router> list = new List<Router>();

            string sqlexpression = "SELECT * FROM router";
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(6)}\t{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(5)}\t{reader.GetName(4)}");
                    while (reader.Read())
                    {
                        object id = reader.GetValue(6);
                        object name = reader.GetValue(0);
                        object companyname = reader.GetValue(1);
                        object antennaamount = reader.GetValue(2);
                        object mac = reader.GetValue(3);
                        object manufacturercountry = reader.GetValue(4);
                        object encryption = reader.GetValue(5);
                        list.Add(new Router((uint)id, (string)name, (int)companyname, (int)antennaamount, (string)mac, (int)manufacturercountry, (int)encryption));
                    }
                }
                reader.Close();
            }
            return list;
        }

        public Company GetCompanyById(int id)
        {
            Company comp = null;
            string sqlexpression = String.Format("SELECT * FROM Company WHERE ID = {0}", id);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                    while (reader.Read())
                    {
                        comp = new Company((int)reader.GetValue(0), (string)reader.GetValue(1));
                    }
                }
                reader.Close();
            }
            return comp;
        }

        public Country GetCountryById(int id)
        {
            Country country = null;
            string sqlexpression = String.Format("SELECT * FROM manufacturercountry WHERE ID = {0}", id);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                    while (reader.Read())
                    {
                        country = new Country((int)reader.GetValue(0), (string)reader.GetValue(1));
                    }
                }
                reader.Close();
            }
            return country;
        }

        public EncriptionType GetEncrById(int id)
        {
            EncriptionType encryptionType = null;
            string sqlexpression = String.Format("SELECT * FROM encryptiontype WHERE ID = {0}", id);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                    while (reader.Read())
                    {
                        encryptionType = new EncriptionType((int)reader.GetValue(0), (string)reader.GetValue(1));
                    }
                }
                reader.Close();
            }
            return encryptionType;
        }

        public void CreateCountry(string name)
        {
            string sqlexpression = string.Format(@"INSERT INTO manufacturercountry (CountryName) VALUES (""{0}"")", name);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine($"Added {number} elements");
            }
        }

        public void CreateCompany(string name)
        {
            string sqlexpression = string.Format(@"INSERT INTO Company (CompanyName) VALUES (""{0}"")", name);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine($"Added {number} elements");
            }
        }

        public void CreateEncryption(string name)
        {
            string sqlexpression = string.Format(@"INSERT INTO encryptiontype (EncryptionName) VALUES (""{0}"")", name);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine($"Added {number} elements");
            }
        }

        public void CreateRouter(Router routertocopy)
        {
            string sqlexpression = string.Format(@"INSERT INTO router (name, CompanyName, AntennaAmount, MAC_Adres, ManufacturerCountry, EncriptionType) VALUES (""{0}"", {1}, {2}, ""{3}"", {4}, {5})", routertocopy.Name, routertocopy.CompanyName, routertocopy.AntennaAmount, routertocopy.MAC_Adress, routertocopy.ManufacturerCountry, routertocopy.EncryptionType);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                int number = command.ExecuteNonQuery();
            }
        }

        public Company GetCompanyByName(string companyname)
        {
            Company comp = null;
            string sqlexpression = String.Format(@"SELECT * FROM Company WHERE CompanyName = ""{0}""", companyname);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                    while (reader.Read())
                    {
                        comp = new Company((int)reader.GetValue(0), (string)reader.GetValue(1));
                    }
                }
                reader.Close();
            }
            return comp;
        }

        public Country GetCountryByName(string countryname)
        {
            Country country = null;
            string sqlexpression = String.Format(@"SELECT * FROM manufacturercountry WHERE CountryName = ""{0}""", countryname);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                    while (reader.Read())
                    {
                        country = new Country((int)reader.GetValue(0), (string)reader.GetValue(1));
                    }
                }
                reader.Close();
            }
            return country;
        }

        public EncriptionType GetEncriptionByName(string encryption)
        {
            EncriptionType encryptionType = null;
            string sqlexpression = String.Format(@"SELECT * FROM encryptiontype WHERE EncryptionName = ""{0}""", encryption);
            using (var connection = Connection.GetInstance().GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlexpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}");
                    while (reader.Read())
                    {
                        encryptionType = new EncriptionType((int)reader.GetValue(0), (string)reader.GetValue(1));
                    }
                }
                reader.Close();
            }
            return encryptionType;
        }
    }
}
