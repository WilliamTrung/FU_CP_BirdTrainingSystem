using Models.ServiceModels.TimetableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;

namespace AppService.TimetableService
{ 
    public interface IServiceManager : IServiceStaff
    {
        Task LogAbsentInDay(AbsentInDayModel absentLog);

        Task LogAbsentDateRange(AbsentDateRangeModel absentLog);
    }
}
