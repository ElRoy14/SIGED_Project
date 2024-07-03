using Siged.Application.Customers.DTOs;
using Siged.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Customers.Interfaces
{
    public interface ICustomerService
    {

        Task<List<GetCustomer>> GetAllCustomerAsync();
        Task<GetCustomer> Register(CreateCustomer model);
        Task<bool> UpdateAsync(UpdateCustomer model);
        Task<bool> DeleteAsync(int id);

        Task<GetCustomer> GetCustomerByIdAsync(int id);
    }
}
