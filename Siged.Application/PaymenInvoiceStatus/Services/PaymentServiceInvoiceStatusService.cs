using AutoMapper;
using Siged.Application.PaymenInvoiceStatus.DTOs;
using Siged.Application.PaymenInvoiceStatus.Exceptions;
using Siged.Application.PaymenInvoiceStatus.Interfaces;
using Siged.Domain;
using Siged.Domain.Interfaces;

namespace Siged.Application.PaymenInvoiceStatus.Services
{
    public class PaymentServiceInvoiceStatusService : IPaymentServiceInvoiceStatusService
    {
        private readonly IGenericRepository<PaymentServiceInvoiceStatus> _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentServiceInvoiceStatusService(
            IGenericRepository<PaymentServiceInvoiceStatus> paymentRepository, 
            IMapper mapper
            )
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPaymentServiceInvoiceStatus>> GetAllPaymentServiceInvoiceStatusAsync()
        {
            try
            {
                var payment = await _paymentRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetPaymentServiceInvoiceStatus>>(payment.ToList());
            }
            catch
            {
                throw new GetPaymentInvoiceStatusFailedException();
            }

        }

    }

}
