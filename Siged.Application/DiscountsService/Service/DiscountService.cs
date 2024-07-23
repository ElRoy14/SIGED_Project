using AutoMapper;
using Siged.Application.DiscountsService.Interface;
using Siged.Domain.Interfaces;
using Siged.Domain;
using Siged.Application.DiscountsService.DTOs;
using Siged.Application.DiscountsService.Exceptions;

namespace Siged.Application.DiscountsService.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IGenericRepository<Discount> _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService(IGenericRepository<Discount> discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<List<GetDiscount>> GetDiscountsAsync()
        {
            try
            {
                var payment = await _discountRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetDiscount>>(payment.ToList());
            }
            catch
            {
                throw new GetDiscountFailedException();
            }

        }

    }

}
