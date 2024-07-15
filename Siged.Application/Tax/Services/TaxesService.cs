using AutoMapper;
using Siged.Application.Tax.Interfaces;
using Siged.Domain.Interfaces;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siged.Application.Tax.DTOs;
using Siged.Application.Roles.DTOs;
using Siged.Application.Roles.Exceptions;
using Siged.Application.Tax.Exceptions;
using Siged.Application.Users.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Siged.Application.Tax.Services
{
    public class TaxesService: ITaxesService
    {
        public readonly IGenericRepository<Taxis> _taxesRepository;
        public readonly IMapper _mapper;

        public TaxesService(IGenericRepository<Taxis> taxesRepository, IMapper mapper)
        {
            _taxesRepository = taxesRepository;
            _mapper = mapper;
        }

        public async Task<List<GetTaxes>> GetAllTaxesAsync()
        {
           
            try
            {
                var taxes = await _taxesRepository.VerifyDataExistenceAsync();

                var listTaxes = taxes
                    .Include(tax => tax.Percentage)
                    .Include(tax => tax.Salary).ToList();

                return _mapper.Map<List<GetTaxes>>(listTaxes);


            }
            catch
            {
                throw new GetTaxesFailedException();
            }
        }
    }
}
