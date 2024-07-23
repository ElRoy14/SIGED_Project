using Siged.Application.PaymentMethods.DTOs;

namespace Siged.Application.PaymentMethods.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<List<GetPaymentMethods>> GetAllPaymentMethods();
    }

}
