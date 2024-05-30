using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Empleados
{
    public class Empleados
    {
        public int? Empleado_id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Cargo { get; set; }

        public string? Departamento { get; set; }

        public string? Superior { get; set; }

        public string? Estatus { get; set; }

        public decimal? Sueldo { get; set; }

        public int? Nomina_Impuesto_AFP_id { get; set; }

    }
}
