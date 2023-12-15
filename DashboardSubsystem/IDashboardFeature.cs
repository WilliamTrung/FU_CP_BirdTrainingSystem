using Models.DashboardModels;
using Models.Enum;
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
        Task<IEnumerable<TransactionModel>> GetTransactions(EntityType? type = null);
    }
}
