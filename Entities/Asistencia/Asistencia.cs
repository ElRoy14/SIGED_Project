using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Asistencia
{
    public class Asistencia
    {
        public int? Asistencia_id { get; set; }

        public int? Empleado_id { get; set; }

        public string? Firma { get; set; }

        public DateTime? HoraEntrada { get; set; }

        public DateTime? HoraSalida { get; set; }

        public decimal? HorasTrabajadas { get; set; }
    }
}
