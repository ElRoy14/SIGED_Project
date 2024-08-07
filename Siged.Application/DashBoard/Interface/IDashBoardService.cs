using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.DashBoard.Interface
{
    public interface IDashBoardService
    {
        Task<int> GetTotalTasksAsync();
        Task<int> GetPendingTasksAsync();
        Task<int> GetDoneTasksAsync();
        Task<int> GetTotalUsersAsync();
        Task<int> GetSuperAdminUsersAsync();
        Task<int> GetManagerUsersAsync();
        Task<int> GetSupervisorUsersAsync();
        Task<int> GetRRHHUsersAsync();
        Task<int> GetEmployeeUsersAsync();
        Task<int> GetTotalInvoiceIssuedAsync();
        Task<int> GetTotalCustomersAsync();
        Task<int> GetTotalSuppliersAsync();
    }
}
