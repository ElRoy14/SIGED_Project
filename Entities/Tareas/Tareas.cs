using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Tareas
{
    public class Tareas
    {
        public int? Tareas_id { get; set; }

        public string? Nombre { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaVencimiento { get; set; }
        
        public string? Estatus { get; set; } //Pendiente, En Progreso, Terminada, En Espera
    }
}
