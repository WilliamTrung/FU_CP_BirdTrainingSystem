using DashboardSubsystem;
using Models.DashboardModels;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DashboardService
{
    public interface IDashboardService
    {
        Task<DashboardConsultingTicket> GetDashboardConsultingTicket();
        Task<DashboardOnlineCourse> GetDashboardOnlineCourse();
        Task<DashboardWorkshop> GetDashboardWorkshop();
        Task<IEnumerable<TransactionModel>> GetTransactions(EntityType? type = null);
        Task<CampaignModel> GetCampaignModel(CampaignQueryModel model);
        Task<IEnumerable<DashboardIncomeLineChartModel>> GetIncomeLineChartModel(int year);
        Task<IEnumerable<TrainerContributionModel>> GetTrainerContributionModels(int month, int year);
    }
}
