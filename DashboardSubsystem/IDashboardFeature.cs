using Models.DashboardModels;
using Models.DashboardModels.PieCartModel;
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
        Task<DashboardTrainingCourse> GetDashboardTrainingCourse();
        Task<IEnumerable<TransactionModel>> GetTransactions(EntityType? type = null);
        Task<CampaignModel> GetCampaignModel(CampaignQueryModel query);
        Task<IEnumerable<DashboardIncomeLineChartModel>> GetIncomeLineChartModel(int year);
        Task<IEnumerable<TrainerContributionModel>> GetTrainerContributionModels(int month, int year);
        Task<PieChartServicesData> GetRatioTotalServices(int year);
    }
}
