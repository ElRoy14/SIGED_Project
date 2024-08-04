using AutoMapper;
using Siged.Application.PaymentMethods.DTOs;
using Siged.Application.PaymentMethods.Exceptions;
using Siged.Application.PaymentMethods.Interfaces;
using Siged.Domain;
using Siged.Domain.Interfaces;

namespace Siged.Application.PaymentMethods.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IGenericRepository<PaymentMethod> _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentMethodService(IGenericRepository<PaymentMethod> paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPaymentMethods>> GetAllPaymentMethods()
        {
            try
            {
                var payment = await _paymentRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetPaymentMethods>>(payment.ToList());
            }
            catch
            {
                throw new GetPaymentMetohdFailedException();
            }

        }

    }

}
