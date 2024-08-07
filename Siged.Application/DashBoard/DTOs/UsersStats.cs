using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.DashBoard.DTOs
{
    public class UsersStats
    {
        public int Total { get; set; }
        public int SuperAdmins { get; set; }
        public int Managers { get; set; }
        public int Supervisors { get; set; }
        public int RRHH { get; set; }
        public int Employees { get; set; }
    }

    public class CustomersStats
    {
        public int Total { get; set; }
    }

    public class SuppliersStats
    {
        public int Total { get; set; }
    }
}
