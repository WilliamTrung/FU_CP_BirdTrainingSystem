using ApplicationService.MailSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    public interface IMailService
    {
        Task SendEmailAsync(string email, MailContent mailContent);
    }
}
