using Persistence.DTOs.Usuarios;
using Persistence.DBConnections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Persistence.Queries.Usuarios
{
    public class UsuariosQueries
    {
        private readonly SqlConnection _conn;

        public UsuariosQueries()
        {
            _conn = DBConnection.Connect();
        }

        public UsuarioDTO GetUsuarioById(int id)
        {
            using (SqlCommand comd = new SqlCommand($"SELECT * FROM Usuarios WHERE Usuario_Id = {id}", _conn))
            {
                _conn.Open(); // Abre la conexión antes de ejecutar el comando

                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var usuario = new UsuarioDTO
                        {
                            UsuarioId = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Correo = reader.GetString(2),
                            Clave = reader.GetString(3)
                        };

                        usuario.Roles = GetRolesByUsuarioId(usuario.UsuarioId);

                        return usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public List<string> GetRolesByUsuarioId(int usuarioId)
        {
            List<string> roles = new List<string>();

            using (SqlCommand comd = new SqlCommand($"SELECT Roles.Nombre FROM Roles INNER JOIN Usuarios ON Roles.Rol_Id = Usuarios.Rol_Id WHERE Usuarios.Usuario_Id = {usuarioId}", _conn))
            {
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString(0));
                    }
                }
            }

            return roles;
        }
    }
}
