using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impuestos
{
    public class Impuesto
    {
        public int? Impuesto_id { get; set; }

        public string? Nombre { get; set; }

        public decimal? Porcentaje { get; set; }
    }
}
