using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practica1.Services.Emails
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}