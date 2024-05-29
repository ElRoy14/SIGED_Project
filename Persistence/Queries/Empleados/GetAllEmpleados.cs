using Persistence.DBConnections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries.Empleados
{
    public class GetAllEmpleados
    {
        private SqlConnection _conn = null;

        public GetAllEmpleados()
        {
            _conn = DBConnection.Connect();
        }

        public void ReadEmpleados()
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand("SELECT * FROM dbo.Empleados", _conn);

                SqlDataReader rd = comd.ExecuteReader();

                try
                {
                    while (rd.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}", rd[0], rd[1]));
                    }
                }
                finally
                {
                    rd.Close();
                }
            }
        }


    }
}
