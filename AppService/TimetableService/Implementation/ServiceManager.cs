using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using SP_Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;

namespace AppService.TimetableService.Implementation
{
    public class ServiceManager : ServiceStaff, IServiceManager
    {
        public ServiceManager(ITimetableFeature timetable) : base(timetable)
        {
        }
    }
}
