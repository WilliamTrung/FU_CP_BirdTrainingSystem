﻿using DashboardSubsystem;
using Models.DashboardModels;
using Models.DashboardModels.PieCartModel;
using Models.Enum;
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

        public ITopFeature Top => _dashboard.Top;

        public DashboardService(IDashboardFeature dashboardFeature)
        {
            _dashboard = dashboardFeature;
        }

        public Task<CampaignModel> GetCampaignModel(CampaignQueryModel model)
        {
            return _dashboard.GetCampaignModel(model);
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
        public Task<DashboardTrainingCourse> GetDashboardTrainingCourse()
        {
            return _dashboard.GetDashboardTrainingCourse();
        }

        public Task<IEnumerable<TransactionModel>> GetTransactions(EntityType? type = null)
        {
            return _dashboard.GetTransactions(type);
        }
        public Task<IEnumerable<DashboardIncomeLineChartModel>> GetIncomeLineChartModel(int year)
        {
            return _dashboard.GetIncomeLineChartModel(year);
        }
        public Task<IEnumerable<TrainerContributionModel>> GetTrainerContributionModels(int month, int year)
        {
            return _dashboard.GetTrainerContributionModels(month, year);
        }
        public Task<PieChartServicesData> GetRatioTotalServices(int year)
        {
            return _dashboard.GetRatioTotalServices(year);
        }
    }
}
