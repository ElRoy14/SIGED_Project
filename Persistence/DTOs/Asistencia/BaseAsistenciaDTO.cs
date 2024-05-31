using Persistence.DTOs.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DTOs.Asistencia
{
    public record BaseAsistenciaDTO : BaseEmpleadoDTO
    {
        public int? Asistencia_id { get; set; }

        public string? Firma { get; set; }

        public DateTime? Fecha { get; set; }

        public DateTime? HoraEntrada { get; set; }

        public DateTime? HoraSalida { get; set; }

        public decimal? HorasTrabajadas { get; set; }
    }
}
