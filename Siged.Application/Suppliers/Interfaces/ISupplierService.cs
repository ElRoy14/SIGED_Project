using Siged.Application.Customers.DTOs;
using Siged.Application.Suppliers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Suppliers.Interfaces
{
    public interface ISupplierService
    {
        Task<List<GetSuppliers>> GetAllCustomerAsync();
        Task<GetSuppliers> Register(CreateSuppliers model);
        Task<bool> UpdateAsync(UpdateSuppliers model);
        Task<bool> DeleteAsync(int id);

        Task<GetSuppliers> GetCustomerByIdAsync(int id);
    }
}
