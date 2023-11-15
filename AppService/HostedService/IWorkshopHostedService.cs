using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.HostedService
{
    public interface IWorkshopHostedService : IDisposable
    {
        Task CheckExceedRegistrationTime();
        Task CheckOpenClasses();
        Task CheckCompleteClasses();
        Task LateCheckAttendance();
    }
}
