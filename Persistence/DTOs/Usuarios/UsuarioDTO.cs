using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DTOs.Usuarios
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public List<string>? Roles { get; set; }
    }


}
