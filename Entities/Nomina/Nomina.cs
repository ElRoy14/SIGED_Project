using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Nomina
{
    public class Nomina
    {
        public int? Nomina_id { get; set; }

        public int? Empleado_id { get; set; }

        public DateTime? FechaPago { get; set; }
        
        public decimal? SalarioBruto { get; set; }

        public decimal? SalarioNeto { get; set; }
    }
}
