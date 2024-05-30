using Persistence.DBConnections;
using Application.DTOs.Empleados;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Persistence.Queries.Empleados
{
    public class EmpleadosQueries
    {
        private SqlConnection _conn = null;

        public EmpleadosQueries()
        {
            _conn = DBConnection.Connect();
        }

        public List<BaseEmpleadoDTO> GetAdmin()
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand("SELECT * FROM dbo.Empleados", _conn);
                
                SqlDataReader reader = comd.ExecuteReader();

                List<BaseEmpleadoDTO> empleados = new List<BaseEmpleadoDTO>();

                try
                {
                    while (reader.Read())
                    {
                        BaseEmpleadoDTO empleado = new BaseEmpleadoDTO();

                        #region Mapear Empleado
                        empleado.empleado_id = reader.GetInt32(0);
                        empleado.Nombre = reader.GetString(1);
                        empleado.Apellido = reader.GetString(2);
                        empleado.Email = reader.GetString(3);
                        empleado.Telefono = reader.GetString(4);
                        empleado.Cargo = reader.GetString(5);
                        empleado.Departamento = reader.GetString(6);
                        empleado.Superior = reader.GetString(7);
                        empleado.Estatus = reader.GetString(8);
                        empleado.Sueldo = reader.GetDecimal(9);
                        empleado.Nomina_Impuesto_AFP_id = reader.GetInt32(10);
                        #endregion

                        empleados.Add(empleado);
                    }
                    return empleados;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public List<SaveEmpleadoDTO> GetEmpleado()
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand("SELECT * FROM dbo.Empleados", _conn);

                SqlDataReader reader = comd.ExecuteReader();

                List<SaveEmpleadoDTO> empleados = new List<SaveEmpleadoDTO>();

                try
                {
                    while (reader.Read())
                    {
                        SaveEmpleadoDTO empleado = new SaveEmpleadoDTO();

                        #region Mapear Empleado
                        empleado.empleado_id = reader.GetInt32(0);
                        empleado.Nombre = reader.GetString(1);
                        empleado.Apellido = reader.GetString(2);
                        empleado.Email = reader.GetString(3);
                        empleado.Telefono = reader.GetString(4);
                        empleado.Cargo = reader.GetString(5);
                        empleado.Departamento = reader.GetString(6);
                        empleado.Superior = reader.GetString(7);
                        empleado.Estatus = reader.GetString(8);
                        #endregion

                        empleados.Add(empleado);
                    }
                    return empleados;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public List<BaseEmpleadoDTO> GetAdminById(int id)
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand($"SELECT * FROM dbo.Empleados WHERE empleado_id = {id}", _conn);

                SqlDataReader reader = comd.ExecuteReader();

                List<BaseEmpleadoDTO> empleados = new List<BaseEmpleadoDTO>();

                try
                {
                    while (reader.Read())
                    {
                        BaseEmpleadoDTO empleado = new BaseEmpleadoDTO();

                        #region Mapear Empleado
                        empleado.empleado_id = reader.GetInt32(0);
                        empleado.Nombre = reader.GetString(1);
                        empleado.Apellido = reader.GetString(2);
                        empleado.Email = reader.GetString(3);
                        empleado.Telefono = reader.GetString(4);
                        empleado.Cargo = reader.GetString(5);
                        empleado.Departamento = reader.GetString(6);
                        empleado.Superior = reader.GetString(7);
                        empleado.Estatus = reader.GetString(8);
                        empleado.Sueldo = reader.GetDecimal(9);
                        empleado.Nomina_Impuesto_AFP_id = reader.GetInt32(10);
                        #endregion

                        empleados.Add(empleado);
                    }
                    return empleados;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public List<SaveEmpleadoDTO> GetEmpleadoById(int id)
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand($"SELECT * FROM dbo.Empleados WHERE empleado_id = {id}", _conn);

                SqlDataReader reader = comd.ExecuteReader();

                List<SaveEmpleadoDTO> empleados = new List<SaveEmpleadoDTO>();

                try
                {
                    while (reader.Read())
                    {
                        SaveEmpleadoDTO empleado = new SaveEmpleadoDTO();

                        #region Mapear Empleado
                        empleado.empleado_id = reader.GetInt32(0);
                        empleado.Nombre = reader.GetString(1);
                        empleado.Apellido = reader.GetString(2);
                        empleado.Email = reader.GetString(3);
                        empleado.Telefono = reader.GetString(4);
                        empleado.Cargo = reader.GetString(5);
                        empleado.Departamento = reader.GetString(6);
                        empleado.Superior = reader.GetString(7);
                        empleado.Estatus = reader.GetString(8);
                        #endregion

                        empleados.Add(empleado);
                    }
                    return empleados;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public int PostAdmin(BaseEmpleadoDTO dto)
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand("INSERT INTO dbo.Empledos(nombre,apellido,email,telefono,cargo,departamento,superior,estatus,sueldo) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9)", _conn);

                SqlDataReader reader = comd.ExecuteReader();

                try
                {
                    BaseEmpleadoDTO empleado = new BaseEmpleadoDTO();

                    #region Mapear Empleado
                    comd.Parameters.AddWithValue("@param1", dto.Nombre);
                    comd.Parameters.AddWithValue("@param2", dto.Apellido);
                    comd.Parameters.AddWithValue("@param3", dto.Email);
                    comd.Parameters.AddWithValue("@param4", dto.Telefono);
                    comd.Parameters.AddWithValue("@param5", dto.Cargo);
                    comd.Parameters.AddWithValue("@param6", dto.Departamento);
                    comd.Parameters.AddWithValue("@param7", dto.Superior);
                    comd.Parameters.AddWithValue("@param8", Entities.Empleados.EstatusEnum.ACTIVO.ToString());
                    comd.Parameters.AddWithValue("@param9", dto.Sueldo);
                    #endregion

                    return comd.ExecuteNonQuery();
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public int PostEmpleado(SaveEmpleadoDTO dto)
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand("INSERT INTO dbo.Empledos(nombre,apellido,email,telefono) VALUES(@param1,@param2,@param3,@param4)", _conn);

                SqlDataReader reader = comd.ExecuteReader();

                try
                {
                    SaveEmpleadoDTO empleado = new SaveEmpleadoDTO();

                    #region Mapear Empleado
                    comd.Parameters.AddWithValue("@param1", dto.Nombre);
                    comd.Parameters.AddWithValue("@param2", dto.Apellido);
                    comd.Parameters.AddWithValue("@param3", dto.Email);
                    comd.Parameters.AddWithValue("@param4", dto.Telefono);
                    #endregion

                    return comd.ExecuteNonQuery();
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public int PutAdmin(BaseEmpleadoDTO dto, int id)
        {
            using (_conn)
            {
                string command = "UPDATE dbo.Empleados " +
                                 "SET nombre = @param1, " +
                                 "apellido = @param2 " +
                                 "email = @param3 " +
                                 "telefono = @param4 " +
                                 "cargo = @param5 " +
                                 "departamento = @param6 " +
                                 "superior = @param7 " +
                                 "estatus = @param8 " +
                                 "sueldo = @param9 " +
                                 $"Where empleado_id = {id}";

                SqlCommand comd = new SqlCommand(command, _conn);

                SqlDataReader reader = comd.ExecuteReader();

                try
                {
                    BaseEmpleadoDTO empleado = new BaseEmpleadoDTO();

                    #region Mapear Empleado
                    comd.Parameters.AddWithValue("@param1", dto.Nombre);
                    comd.Parameters.AddWithValue("@param2", dto.Apellido);
                    comd.Parameters.AddWithValue("@param3", dto.Email);
                    comd.Parameters.AddWithValue("@param4", dto.Telefono);
                    comd.Parameters.AddWithValue("@param5", dto.Cargo);
                    comd.Parameters.AddWithValue("@param6", dto.Departamento);
                    comd.Parameters.AddWithValue("@param7", dto.Superior);
                    comd.Parameters.AddWithValue("@param8", dto.Estatus);
                    comd.Parameters.AddWithValue("@param9", dto.Sueldo);
                    #endregion

                    return comd.ExecuteNonQuery();
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public int PutEmpleado(SaveEmpleadoDTO dto, int id)
        {
            using (_conn)
            {
                string command = "UPDATE dbo.Empleados " +
                                 "SET nombre = @param1, " +
                                 "apellido = @param2 " +
                                 "email = @param3 " +
                                 "telefono = @param4 " +
                                 $"Where empleado_id = {id}";

                SqlCommand comd = new SqlCommand(command, _conn);

                SqlDataReader reader = comd.ExecuteReader();

                try
                {

                    #region Mapear Empleado
                    comd.Parameters.AddWithValue("@param1", dto.Nombre);
                    comd.Parameters.AddWithValue("@param2", dto.Apellido);
                    comd.Parameters.AddWithValue("@param3", dto.Email);
                    comd.Parameters.AddWithValue("@param4", dto.Telefono);
                    #endregion

                    return comd.ExecuteNonQuery();
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public int Delete(int id)
        {
            using (_conn)
            {
                SqlCommand comd = new SqlCommand($"DELETE FROM dbo.Empleado WHERE empleado_id= {id}", _conn);

                SqlDataReader reader = comd.ExecuteReader();

                try
                {
                    return comd.ExecuteNonQuery();
                }
                finally
                {
                    reader.Close();
                }
            }
        }
    }
}
