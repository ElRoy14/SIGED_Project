using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Usuarios
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public int RolId { get; set; } // Esto representa la relación con el rol

        // Propiedad de navegación para acceder al rol del usuario
        public Rol Rol { get; set; }
    }
}
