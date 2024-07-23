using Siged.Application.AppliedTaxes.DTOs;

namespace Siged.Application.AppliedTaxes.Interfaces
{
    public interface IAppliedTaxesService
    {
        Task<List<GetAppliedTaxe>> GetAppliedTaxeListAsync();
    }

}
