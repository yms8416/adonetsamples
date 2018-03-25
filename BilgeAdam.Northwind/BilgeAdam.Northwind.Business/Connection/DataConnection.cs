using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Northwind.Business.Connection
{
    static class DataConnection
    {
        //static DataConnection()
        //{
        //    İlk seferde otomatik olarak çağrılır ve bir daha çalışmaz
        //}
        private static SqlConnection connection;
        private static object _lock = new object();
        public static SqlConnection Connect()
        {
            //Singleton Design Pattern
            if (connection == null)
            {
                lock (_lock)
                {
                    if (connection == null)
                    {
                        var cstr = ConfigurationManager.ConnectionStrings["awconnstr"].ConnectionString;
                        
                        connection = new SqlConnection(cstr);
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                    }
                }
            }
            return connection;
        }
    }
}
