using Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardSubsystem
{
    public interface IDashboardFeature
    {
        Task<DashboardConsultingTicket> GetDashboardConsultingTicket();
        Task<DashboardOnlineCourse> GetDashboardOnlineCourse();
        Task<DashboardWorkshop> GetDashboardWorkshop();
    }
}
