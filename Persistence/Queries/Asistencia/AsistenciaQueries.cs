using Persistence.DTOs.Asistencia;
using Persistence.DTOs.Empleados;
using Persistence.DBConnections;
using Persistence.Queries.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
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

        public BaseAsistenciaDTO GetById(int id)
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand($"SELECT * FROM vw_ResumenAsistencia WHERE empleado_id = {id}", _conn);

                SqlDataReader reader = comd.ExecuteReader();

                List<BaseAsistenciaDTO> asistencias = new List<BaseAsistenciaDTO>();

                try
                {
                    BaseAsistenciaDTO asistencia = new BaseAsistenciaDTO();

                    reader.Read();

                    #region Mapear Asistencia
                    asistencia.Nombre = reader.GetString(1);
                    asistencia.Apellido = reader.GetString(2);
                    asistencia.Fecha = reader.GetDateTime(3);
                    asistencia.HoraEntrada = reader.GetDateTime(4);
                    asistencia.HoraSalida = reader.GetDateTime(5);
                    asistencia.HorasTrabajadas = reader.GetDecimal(6);
                    #endregion

                    return asistencia;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public List<BaseAsistenciaDTO> GetByDate(DateTime fecha) 
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand($"SELECT * FROM vw_ResumenAsistencia WHERE fecha = {fecha}", _conn);

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

        public int RegistrarEntrada(BaseAsistenciaDTO dto)
        {

            using (_conn)
            {
                SqlCommand comd = new SqlCommand("RegistrarEntrada", _conn);

                comd.CommandType = CommandType.StoredProcedure;

                try
                {
                    BaseAsistenciaDTO empleado = new BaseAsistenciaDTO();

                    #region Mapear Asistencia
                    comd.Parameters.AddWithValue("@Nombre", dto.Nombre);
                    comd.Parameters.AddWithValue("@Apellido", dto.Apellido);
                    comd.Parameters.AddWithValue("@Firma", dto.Firma);
                    comd.Parameters.AddWithValue("@Fecha", dto.Fecha);
                    comd.Parameters.AddWithValue("@HoraEntrada", dto.HoraEntrada);
                    #endregion

                    return comd.ExecuteNonQuery();
                }catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int RegistrarSalida(BaseAsistenciaDTO dto)
        {

            using (_conn)
            {
                SqlCommand comd = new SqlCommand("RegistrarSalida", _conn);

                comd.CommandType = CommandType.StoredProcedure;

                try
                {
                    BaseAsistenciaDTO empleado = new BaseAsistenciaDTO();

                    #region Mapear Asistencia
                    comd.Parameters.AddWithValue("@Nombre", dto.Nombre);
                    comd.Parameters.AddWithValue("@Apellido", dto.Apellido);
                    comd.Parameters.AddWithValue("@Fecha", dto.Fecha);
                    comd.Parameters.AddWithValue("@HoraSalida", dto.HoraSalida);
                    #endregion

                    return comd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
