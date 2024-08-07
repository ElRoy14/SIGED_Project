using Siged.Application.ServicePaymentInvoices.DTOs;
using Siged.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ServicePaymentInvoices.Interfaces
{
    public interface IServicePaymentInvoiceService
    {
        Task<List<GetServicePaymentInvoice>> GetPaymentInvoicesAsync();
        Task<GetServicePaymentInvoice> Register(CreateServicePaymentInvoice model);
    }
}
