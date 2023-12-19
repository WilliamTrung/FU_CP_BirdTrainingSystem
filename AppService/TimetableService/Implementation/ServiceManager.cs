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
            //check time is 
            if(!CheckTime(absentLog.SelectedDate))
            {
                throw new InvalidOperationException("Invalid logged time!");
            }
            await _logAbsent.LogAbsentInDay(absentLog);
        }
        public async Task LogAbsentDateRange(AbsentDateRangeModel absentLog)
        {
            if (!CheckTime(absentLog.From) || !CheckTime(absentLog.To))
            {
                throw new InvalidOperationException("Invalid logged time!");
            }
            await _logAbsent.LogAbsentDateRange(absentLog);
        }
        private bool CheckTime(DateOnly checkDate)
        {
            // can only be logged freely within the whole month exclude the last 3 days of the month
            //check within month
            int currentMonth = DateTime.UtcNow.AddHours(7).Month;
            if(currentMonth != checkDate.Month)
            {
                return false;
            }
            //check 3 last days in month
            int daysInMonth = DateTime.DaysInMonth(checkDate.Year, checkDate.Month);
            if(checkDate.Day > daysInMonth - 3)
            {
                return false;
            }
            return true;
        }
    }
}
