using Siged.Application.Roles.DTOs;
using Siged.Application.Tax.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Tax.Interfaces
{
    public interface ITaxesService
    {
        Task<List<GetTaxes>> GetAllTaxesAsync();
    }
}
