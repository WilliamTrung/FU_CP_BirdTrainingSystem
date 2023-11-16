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
        //Task CheckExceedRegistrationTime(); -- staff will do
        //Task CheckOpenClasses(); -- staff will do

        //check full customer

        Task CheckCompleteClasses(); 
        Task LateCheckAttendance();
        //Task CheckOpenRegistration(); -- staff will do
    }
}
