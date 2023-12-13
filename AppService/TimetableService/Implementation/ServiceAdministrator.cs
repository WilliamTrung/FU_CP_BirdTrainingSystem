using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;

namespace AppService.TimetableService.Implementation
{
    public class ServiceAdministrator : IServiceAdministrator
    {
        private readonly ITimetableFeature _timetable;
        public ServiceAdministrator(ITimetableFeature timetable) 
        { 
            _timetable = timetable;
        }

        public async Task UpdateSlot(int minute)
        {
            await _timetable.UpdateSlot(minute);
        }
    }
}
