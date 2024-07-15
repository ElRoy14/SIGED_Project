using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Suppliers.DTOs
{
    public  class GetSuppliers
    {

        public int SupplierId { get; set; }

        public string? IdentificationCard { get; set; }

        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}
