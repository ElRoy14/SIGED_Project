using Siged.Application.PaymenInvoiceStatus.DTOs;

namespace Siged.Application.PaymenInvoiceStatus.Interfaces
{
    public interface IPaymentServiceInvoiceStatusService
    {
        Task<List<GetPaymentServiceInvoiceStatus>> GetAllPaymentServiceInvoiceStatusAsync();
    }

}
