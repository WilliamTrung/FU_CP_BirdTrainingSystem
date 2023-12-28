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
            // can only be logged freely within the whole month exclude the last 3 days of the month
            CheckTime(absentLog.SelectedDate);
            await _logAbsent.LogAbsentInDay(absentLog);
        }
        public async Task LogAbsentDateRange(AbsentDateRangeModel absentLog)
        {
            // can only be logged freely within the whole month exclude the last 3 days of the month
            CheckTime(absentLog.From);
            CheckTime(absentLog.To);
            await _logAbsent.LogAbsentDateRange(absentLog);
        }
        private void CheckTime(DateOnly checkDate)
        {
            // can only be logged freely within the whole month exclude the last 3 days of the month
            //check within month
            var currentTime = DateTime.UtcNow.AddHours(7);
            int currentMonth = currentTime.Month;
            if(currentMonth != checkDate.Month)
            {
                throw new InvalidOperationException("Invalid logged time!");
            }
            //check 3 last days in month
            int daysInMonth = DateTime.DaysInMonth(checkDate.Year, checkDate.Month);
            int currentDay = DateTime.UtcNow.AddHours(7).Day;
            if (currentDay >= daysInMonth - 3)
            {
                throw new InvalidOperationException("Cannot log absent at last 3 days in month!");
            }
        }
    }
}
