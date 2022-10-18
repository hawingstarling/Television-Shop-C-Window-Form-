using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace EShop.DAO
{
    internal class DataProvider
    {
        private static DataProvider _instance;


        public static DataProvider Instance
        {
            get { if (_instance == null) _instance = new DataProvider();
                return DataProvider._instance;
            }
            private set { DataProvider._instance = value; }
        }

        public DataProvider() { }

        public static string strConn = "SERVER=localhost; uid=root; DATABASE=quanlytivi; port=3306";

        public static MySqlConnection GetConnection()
        {
            MySqlConnection _conn = new MySqlConnection(strConn);

            return _conn;
        }
        
        public static void OpenConnection()
        {
            try
            {
                if (GetConnection().State == ConnectionState.Closed)
                {

                    Console.WriteLine("Connecting to MySQL...");
                    GetConnection().Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connected" + ex.Message);
            }
        }

        public static void CloseConnection()
        {
            try
            {
                if (GetConnection().State == ConnectionState.Open)
                {
                    Console.WriteLine("Disconnecting ...");
                    GetConnection().Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disconnected" + ex.Message);
            }
        }

        public bool ExecuteReader(string query, object[] paramater)
        {
            MySqlConnection _conn = new MySqlConnection(strConn);

            MySqlCommand _command = new MySqlCommand(query, _conn);
            _conn.Open();

            string[] listParamater = query.Split(' ');
            int i = 0;

            foreach(string item in listParamater)
            {
                if (item.Contains("@"))
                {
                    _command.Parameters.AddWithValue(item, paramater[i]);
                    i++;
                }
            }

            MySqlDataReader reader = _command.ExecuteReader();
            if (!reader.HasRows) return false;
            _conn.Close();
            return true;
        }

        public DataTable ExecuteQuery(string query, object[] paramater = null)
        {
            DataTable _dt = new DataTable();
            using (GetConnection())
            {
                OpenConnection();
                MySqlCommand _command = new MySqlCommand(query, GetConnection());

                if (paramater != null)
                {
                    string[] listParamater = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParamater)
                    {
                        if (item.Contains('@'))
                        {
                            _command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                MySqlDataAdapter _da = new MySqlDataAdapter(_command);
                _da.Fill(_dt);
                CloseConnection();
            }
            return _dt;
        }

        public int ExecuteNonQuery(string query, object[] paramater = null)
        {
            int data = 0;

            using (GetConnection())
            {
                OpenConnection();

                MySqlCommand _command = new MySqlCommand(query, GetConnection());

                if (paramater != null)
                {
                    string[] listParamater = query.Split(' ');
                    int i = 0;

                    foreach (string item in listParamater)
                    {
                        if (item.Contains('@'))
                        {
                            _command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }
                data = _command.ExecuteNonQuery();
                CloseConnection();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] paramater = null)
        {
            object data = 0;

            using (GetConnection())
            {
                OpenConnection();

                MySqlCommand _command = new MySqlCommand(query, GetConnection());

                if (paramater != null)
                {
                    string[] listParamater = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParamater)
                    {
                        if (item.Contains('@'))
                        {
                            _command.Parameters.AddWithValue(query, paramater[i]);
                            i++;
                        }
                    }
                }
                data = _command.ExecuteNonQuery();
                CloseConnection();
            }
            return data;
        }

        public DataSet ExcuteQueryList(string query, object[] paramater = null)
        {
            DataSet _ds = new DataSet();
            using (GetConnection()) 
            {
                OpenConnection();
                MySqlCommand _command = new MySqlCommand(query, GetConnection());

                if (paramater != null)
                {
                    string[] listParamater = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParamater)
                    {
                        if (item.Contains('@'))
                        {
                            _command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                MySqlDataAdapter _da = new MySqlDataAdapter(_command);
                _da.Fill(_ds);
                CloseConnection();
            }
            return _ds;
        }
    }
}
