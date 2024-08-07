using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Siged.Application.Email.DTOs;
using Siged.Application.Email.Exceptions;
using Siged.Application.Email.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Email.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailDto request)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserName").Value));
                email.To.Add(MailboxAddress.Parse(request.Addresee));
                email.Subject = request.Subject;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = request.Body
                };

                using var smtp = new SmtpClient();
                smtp.Connect(
                    _config.GetSection("Email:Host").Value,
                    Convert.ToInt32(_config.GetSection("Email:Port").Value),
                    SecureSocketOptions.StartTls
                    );

                smtp.Authenticate(_config.GetSection("Email:UserName").Value, _config.GetSection("Email:PassWord").Value);

                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch
            {
                throw new SendEmailFailedException();
            }
        }
    }
}
