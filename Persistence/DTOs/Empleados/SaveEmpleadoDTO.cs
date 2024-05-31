using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DTOs.Empleados
{
    public record SaveEmpleadoDTO
    {
        public int? empleado_id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Cargo { get; set; }

        public string? Departamento { get; set; }

        public string? Superior { get; set; }

        public string? Estatus { get; set; }
    }
}
