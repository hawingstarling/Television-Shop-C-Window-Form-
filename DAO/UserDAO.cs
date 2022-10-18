using EShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DAO
{
    public class UserDAO
    {
        private static UserDAO _instance;
        public static UserDAO Instance 
        { 
            get { if (_instance == null) _instance = new UserDAO(); 
                return _instance; 
            }
            private set { _instance = value; }
        }

        public UserDAO() { }

        public bool Login(string username, string password)
        {
            string query = @"select USERNAME , PASSWORD from USER where USERNAME = @username and PASSWORD = @password";
            var reader = DataProvider.Instance.ExecuteReader(query, new object[] { username, password });
            return reader;
        }
    }
    }
