using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.DashBoard.DTOs
{
    public class TasksStats
    {
        public int Total { get; set; }
        public int Pending { get; set; }
        public int Done { get; set; }
    }

    public class InvoiceStats
    {
        public int Total { get; set; }
    }
}
