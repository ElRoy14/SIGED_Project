using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Asistencia
{
    public class SaveAsistenciaDTO
    {
        public int? Empleado_id { get; set; }

        public string? Firma { get; set; }

        public decimal? HorasTrabajadas { get; set; }
    }
}
