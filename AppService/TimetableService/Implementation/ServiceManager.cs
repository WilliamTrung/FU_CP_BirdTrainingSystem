using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TimetableModels;
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
        private readonly ILogAbsentFeature _logAbsent;
        public ServiceManager(ITimetableFeature timetable, ILogAbsentFeature logAbsent) : base(timetable)
        {
            _logAbsent = logAbsent;
        }
        public async Task LogAbsentInDay(AbsentInDayModel absentLog)
        {
            await _logAbsent.LogAbsentInDay(absentLog);
        }
        public async Task LogAbsentDateRange(AbsentDateRangeModel absentLog)
        {
            await _logAbsent.LogAbsentDateRange(absentLog);
        }
    }
}
