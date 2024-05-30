using Application.DTOs.Asistencia;
using Application.DTOs.Empleados;
using Persistence.DBConnections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries.Asistencia
{
    public class AsistenciaQueries
    {
        private SqlConnection _conn = null;

        public AsistenciaQueries() 
        {
            _conn = DBConnection.Connect();
        }

        public List<BaseAsistenciaDTO> Get()
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand("SELECT * FROM vw_ResumenAsistencia", _conn);

                SqlDataReader reader = comd.ExecuteReader();

                List<BaseAsistenciaDTO> asistencias = new List<BaseAsistenciaDTO>();

                try
                {
                    while (reader.Read())
                    {
                        BaseAsistenciaDTO asistencia = new BaseAsistenciaDTO();

                        #region Mapear Asistencia
                        asistencia.Nombre = reader.GetString(1);
                        asistencia.Apellido = reader.GetString(2);
                        asistencia.Fecha = reader.GetDateTime(3);
                        asistencia.HoraEntrada = reader.GetDateTime(4);
                        asistencia.HoraSalida = reader.GetDateTime(5);
                        asistencia.HorasTrabajadas = reader.GetDecimal(6);
                        #endregion

                        asistencias.Add(asistencia);
                    }
                    return asistencias;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public List<BaseAsistenciaDTO> GetById(int id)
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand("SELECT * FROM vw_ResumenAsistencia", _conn);

                SqlDataReader reader = comd.ExecuteReader();

                List<BaseAsistenciaDTO> asistencias = new List<BaseAsistenciaDTO>();

                try
                {
                    while (reader.Read())
                    {
                        BaseAsistenciaDTO asistencia = new BaseAsistenciaDTO();

                        #region Mapear Asistencia
                        asistencia.Nombre = reader.GetString(1);
                        asistencia.Apellido = reader.GetString(2);
                        asistencia.Fecha = reader.GetDateTime(3);
                        asistencia.HoraEntrada = reader.GetDateTime(4);
                        asistencia.HoraSalida = reader.GetDateTime(5);
                        asistencia.HorasTrabajadas = reader.GetDecimal(6);
                        #endregion

                        asistencias.Add(asistencia);
                    }
                    return asistencias;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

    }
}
