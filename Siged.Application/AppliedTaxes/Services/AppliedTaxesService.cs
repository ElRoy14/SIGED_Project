using AutoMapper;
using Siged.Application.AppliedTaxes.DTOs;
using Siged.Application.AppliedTaxes.Exceptions;
using Siged.Application.AppliedTaxes.Interfaces;
using Siged.Domain;
using Siged.Domain.Interfaces;

namespace Siged.Application.AppliedTaxes.Services
{
    public class AppliedTaxesService : IAppliedTaxesService
    {
        private readonly IGenericRepository<AppliedTaxis> _appliedTaxesRepository;
        private readonly IMapper _mapper;

        public AppliedTaxesService(IGenericRepository<AppliedTaxis> appliedTaxesRepository, IMapper mapper)
        {
            _appliedTaxesRepository = appliedTaxesRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAppliedTaxe>> GetAppliedTaxeListAsync()
        {
            try
            {
                var applied = await _appliedTaxesRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetAppliedTaxe>>(applied.ToList());
            }
            catch
            {
                throw new GetAppliedTaxFailedException();
            }

        }

    }

}
