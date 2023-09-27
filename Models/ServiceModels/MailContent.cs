using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.MailSettings
{
    public class MailContent
    {
        public string Subject { get; set; } = null!;
        public string HtmlMessage { get; set; } = null!;
                
    }
}
