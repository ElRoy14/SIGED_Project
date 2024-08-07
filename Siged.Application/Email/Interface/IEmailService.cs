using Siged.Application.Email.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Email.Interface
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
