using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NoSQL_Lab
{
    class Connection : IDisposable
    {
        static Connection _instance = null;
        private MySqlConnection connect = null;

        private Connection()
        {
            connect = new MySqlConnection("Server=localhost;Database=marchdb;port=3306;User Id=root;password=root");
        }

        public static Connection GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Connection();
                return _instance;
            }
            return _instance;
        }

        public void OpenConnection()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
                connect.Open();
        }

        public void CloseConnection()
        {
            if (connect.State == System.Data.ConnectionState.Open)
                connect.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connect;
        }

        public void Dispose()
        {
            connect.Close();
        }
    }
}

