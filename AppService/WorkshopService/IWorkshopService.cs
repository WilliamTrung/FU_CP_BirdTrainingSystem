using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService
{
    public interface IWorkshopService
    {
        IServiceCustomer CustomerService { get; }
        IServiceStaff StaffService { get; }
        IServiceManager ManagerService { get; }
        IServiceTrainer TrainerService { get; }
    }
}
