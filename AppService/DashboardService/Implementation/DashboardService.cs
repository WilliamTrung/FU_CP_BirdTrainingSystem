using DashboardSubsystem;
using Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DashboardService.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardFeature _dashboard;
        public DashboardService(IDashboardFeature dashboardFeature)
        {
            _dashboard = dashboardFeature;
        }
        public Task<DashboardConsultingTicket> GetDashboardConsultingTicket()
        {
            return _dashboard.GetDashboardConsultingTicket();
        }

        public Task<DashboardOnlineCourse> GetDashboardOnlineCourse()
        {
            return _dashboard.GetDashboardOnlineCourse();
        }

        public Task<DashboardWorkshop> GetDashboardWorkshop()
        {
            return _dashboard.GetDashboardWorkshop();
        }

        public Task<IEnumerable<TransactionModel>> GetTransactions()
        {
            return _dashboard.GetTransactions();
        }
    }
}
