using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Siged.Application.ServicePaymentInvoices.DTOs;
using Siged.Application.ServicePaymentInvoices.Exceptions;
using Siged.Application.ServicePaymentInvoices.Interfaces;
using Siged.Application.ServicePaymentInvoices.Validators;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Exceptions;
using Siged.Application.Users.Validators;
using Siged.Domain;
using Siged.Domain.Enums;
using Siged.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ServicePaymentInvoices.Services
{
    public class ServicePaymentInvoiceService : IServicePaymentInvoiceService
    {
        private readonly IGenericRepository<ServicePaymentInvoice> _invoiceRepository;
        private readonly IMapper _mapper;

        public ServicePaymentInvoiceService(
            IGenericRepository<ServicePaymentInvoice> invoiceRepository
            , IMapper mapper
            )
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<List<GetServicePaymentInvoice>> GetPaymentInvoicesAsync()
        {
            try
            {
                var invoice = await _invoiceRepository.VerifyDataExistenceAsync();
                var listInvoice = invoice
                    .Include(invo => invo.User)
                    .Include(invo => invo.ServiceName)
                    .Include(invo => invo.PaymentMethod)
                    .Include(invo => invo.AppliedTaxes)
                    .Include(invo => invo.Discounts)
                    .Include(invo => invo.PaymentServiceInvoiceStatus).ToList();

                return _mapper.Map<List<GetServicePaymentInvoice>>(listInvoice);
            }
            catch
            {
                throw new GetInvoiceFailedException();
            }

        }

        //public async Task<GetServicePaymentInvoice> Register(CreateServicePaymentInvoice model)
        //{
        //    try
        //    {
        //        var createInvoiceValidator = new CreateInvoiceValidator();
        //        var validationResult = createInvoiceValidator.Validate(model);

        //        if (!validationResult.IsValid)
        //        {
        //            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
        //            throw new TaskCanceledException($"{string.Join(", ", errors)}");
        //        }

        //        var invoiceCreated = await _invoiceRepository.CreateAsync(_mapper.Map<ServicePaymentInvoice>(model));

        //        var invoiceException = invoiceCreated.ServiceInvoiceId == (int)DataCreationOption.DoNotCreate ? throw new InvoiceNotCreatedException() : invoiceCreated;

        //        var query = await _invoiceRepository.VerifyDataExistenceAsync(i => i.ServiceInvoiceId == invoiceCreated.ServiceInvoiceId);
        //        invoiceCreated = query
        //            .Include(invo => invo.User)
        //            .Include(invo => invo.ServiceName)
        //            .Include(invo => invo.PaymentMethod)
        //            .Include(invo => invo.AppliedTaxes)
        //            .Include(invo => invo.Discounts)
        //            .Include(invo => invo.PaymentServiceInvoiceStatus).First();

        //        return _mapper.Map<GetServicePaymentInvoice>(invoiceCreated);

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        public async Task<GetServicePaymentInvoice> Register(CreateServicePaymentInvoice model)
        {
            try
            {
                ValidateModel(model);

                var invoiceCreated = await CreateInvoiceAsync(model);

                _ = (invoiceCreated.ServiceInvoiceId == (int)DataCreationOption.DoNotCreate)
                    ? throw new InvoiceNotCreatedException()
                    : invoiceCreated;

                var invoice = await GetInvoiceWithDetailsAsync(invoiceCreated.ServiceInvoiceId);

                return MapToGetServicePaymentInvoice(invoice);
            }
            catch
            {
                throw;
            }

        }


        private void ValidateModel(CreateServicePaymentInvoice model)
        {
            var createInvoiceValidator = new CreateInvoiceValidator();
            var validationResult = createInvoiceValidator.Validate(model);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                throw new TaskCanceledException($"{string.Join(", ", errors)}");
            }
        }

        private async Task<ServicePaymentInvoice> CreateInvoiceAsync(CreateServicePaymentInvoice model)
        {
            return await _invoiceRepository.CreateAsync(_mapper.Map<ServicePaymentInvoice>(model));
        }

        private async Task<ServicePaymentInvoice> GetInvoiceWithDetailsAsync(int serviceInvoiceId)
        {
            var query = await _invoiceRepository.VerifyDataExistenceAsync(i => i.ServiceInvoiceId == serviceInvoiceId);
            return query
                .Include(invo => invo.User)
                .Include(invo => invo.ServiceName)
                .Include(invo => invo.PaymentMethod)
                .Include(invo => invo.AppliedTaxes)
                .Include(invo => invo.Discounts)
                .Include(invo => invo.PaymentServiceInvoiceStatus).FirstOrDefault();

        }

        private GetServicePaymentInvoice MapToGetServicePaymentInvoice(ServicePaymentInvoice invoice)
        {
            return _mapper.Map<GetServicePaymentInvoice>(invoice);
        }


    }

}
