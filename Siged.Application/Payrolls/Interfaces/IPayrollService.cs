using Siged.Application.Customers.DTOs;
using Siged.Application.Payrolls.DTOs;
using Siged.Application.Tax.DTOs;
using Siged.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Payrolls.Interfaces
{
    public interface IPayrollService
    {
        Task<List<GetPayroll>> GetAllPayrollsAsync();

        Task<GetPayroll> Register(CreatePayroll model);
        Task<bool> UpdateAsync(UpdatePayroll model);
        Task<bool> DeleteAsync(int id);

        Task<GetPayroll> GetPayrollByIdAsync(int id);
    }

}
