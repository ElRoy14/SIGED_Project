using Siged.Application.DiscountsService.DTOs;

namespace Siged.Application.DiscountsService.Interface
{
    public interface IDiscountService
    {
        Task<List<GetDiscount>> GetDiscountsAsync();
    }

}
