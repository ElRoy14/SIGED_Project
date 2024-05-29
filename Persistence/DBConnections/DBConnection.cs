using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DBConnections
{
    public class DBConnection
    {
        private static SqlConnection _conn = null;

        public static SqlConnection Connect()
        {

            _conn = new SqlConnection("Data Source=DESKTOP-DIAEIQN\\SQLEXPRESS;Initial Catalog=SIGED; Integrated Security=true"); 

            if(_conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
            }
            _conn.Open();

            return _conn;

        }

    }
}
