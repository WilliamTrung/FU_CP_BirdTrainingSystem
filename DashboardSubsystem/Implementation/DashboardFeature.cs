using AppRepository.UnitOfWork;
using AutoMapper;
using Models.DashboardModels;
using Models.Entities;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DashboardSubsystem.Implementation
{
    public class DashboardFeature : IDashboardFeature
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public DashboardFeature(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow; 
        }

        public async Task<CampaignModel> GetCampaignModel(CampaignQueryModel query)
        {
            var transactions = await _uow.TransactionRepository.Get(null, nameof(Transaction.Customer)
                                                                        , $"{nameof(Transaction.Customer)}.{nameof(Customer.User)}");
            decimal? totalRevenue = transactions.Sum(c => c.TotalPayment);
            
            if(query.Month == 1)
            {
                var revenuePrevMonth = transactions.Where(c => c.PaymentDate.Value.Month == 12 && c.PaymentDate.Value.Year == query.Year - 1).Sum(c => c.TotalPayment);
                var revenueThisMonth = transactions.Where(c => c.PaymentDate.Value.Month == query.Month && c.PaymentDate.Value.Year == query.Year).Sum(c => c.TotalPayment);
                decimal percentRevenueFromLastMonth = revenueThisMonth.Value / (revenueThisMonth.Value + revenuePrevMonth.Value);//(revenueThisMonth.Value / revenuePrevMonth.Value) * 100;
                CampaignModel model = new CampaignModel()
                {
                    PercentRevenueFromLastMonth = percentRevenueFromLastMonth,
                    RevenueInMonth = revenueThisMonth.Value,
                    RevenueInYear = totalRevenue.Value
                };
                return model;
            } else
            {
                var revenuePrevMonth = transactions.Where(c => c.PaymentDate.Value.Month == query.Month-1 && c.PaymentDate.Value.Year == query.Year).Sum(c => c.TotalPayment);
                var revenueThisMonth = transactions.Where(c => c.PaymentDate.Value.Month == query.Month && c.PaymentDate.Value.Year == query.Year).Sum(c => c.TotalPayment);
                decimal percentRevenueFromLastMonth = revenueThisMonth.Value / (revenueThisMonth.Value + revenuePrevMonth.Value);// (revenueThisMonth.Value / revenuePrevMonth.Value) * 100;
                CampaignModel model = new CampaignModel()
                {
                    PercentRevenueFromLastMonth = percentRevenueFromLastMonth,
                    RevenueInMonth = revenueThisMonth.Value,
                    RevenueInYear = totalRevenue.Value
                };
                return model;
            }
        }

        public async Task<DashboardConsultingTicket> GetDashboardConsultingTicket()
        {
            var entities = await _uow.ConsultingTicketRepository.Get();
            var totalAmount = entities.Count();
            var unhandledAmount = entities.Count(c => c.Status == (int)Models.Enum.ConsultingTicket.Status.WaitingForApprove);
            var handledAmount = entities.Count(c => c.Status != (int)Models.Enum.ConsultingTicket.Status.WaitingForApprove);

            float handledRatio = (float) handledAmount / totalAmount;
            var model = new DashboardConsultingTicket()
            {
                HandledRatio = handledRatio,
                TotalAmount = totalAmount,
                HandledTicket = handledAmount,
                UnhandledTicket = unhandledAmount,
            };
            return model;
        }

        public async Task<DashboardOnlineCourse> GetDashboardOnlineCourse()
        {
            var entities = await _uow.CustomerOnlineCourseDetailRepository.Get();
            var totalAmount = entities.Count();
            var completed = entities.Count(c => c.Status == (int)Models.Enum.OnlineCourse.Customer.OnlineCourse.Status.Completed);

            var model = new DashboardOnlineCourse()
            {
                TotalAttempts = totalAmount,
                CustomerCompleted = completed,
                CompleteCourseRatio = (float)completed / totalAmount,
            };
            return model;
        }

        public async Task<DashboardWorkshop> GetDashboardWorkshop()
        {
            var entities = await _uow.CustomerWorkshopClassRepository.Get();
            var totalAmount = entities.Count();
            var attendances = await _uow.WorkshopAttendanceRepository.Get(c => c.Status != (int)Models.Enum.Workshop.Class.Customer.Status.NotYet);
            var totalAttendance = attendances.Count();
            var presentAmount = attendances.Count(c => c.Status == (int)Models.Enum.Workshop.Class.Customer.Status.Attended);
            float presentRatio = (float)presentAmount / totalAttendance;

            var classes = await _uow.WorkshopClassRepository.Get(c => c.Workshop.Status == (int)Models.Enum.Workshop.Status.Active
                                                                    && c.Status != (int)Models.Enum.Workshop.Class.Status.Cancelled
                                                                    && c.Status != (int)Models.Enum.Workshop.Class.Status.Completed
                                                                    , nameof(WorkshopClass.Workshop));
            var model = new DashboardWorkshop()
            {
                CustomerAttempts = totalAmount,
                PresentRatio = presentRatio,
                WorkshopClass = classes.Count(),
            };
            return model;

        }
#pragma warning disable CS8629 // Nullable value type may be null.
        public async Task<IEnumerable<DashboardIncomeLineChartModel>> GetIncomeLineChartModel(int year)
        {
            var result = new List<DashboardIncomeLineChartModel>();
            var onlineCourseData = new DashboardIncomeLineChartModel()
            {
                Id = 1,
                Label = "Online Course"
            };
            var consultantData = new DashboardIncomeLineChartModel()
            {
                Id = 2,
                Label = "Advice Consultant"
            };
            var workshopData = new DashboardIncomeLineChartModel()
            {
                Id = 3,
                Label = "Workshop"
            };
            var trainingCourseData = new DashboardIncomeLineChartModel()
            {
                Id = 4,
                Label = "Training Course"
            };
            result.Add(onlineCourseData);
            result.Add(consultantData);
            result.Add(workshopData);
            result.Add(trainingCourseData);
            var transactionsInYear = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year);
            var currentMonth = DateTime.UtcNow.AddHours(7).Month;
            for (int i = 0; i < currentMonth; i++)
            {
                int month = i + 1;
                var transactionInMonth = transactionsInYear.Where(c => c.PaymentDate.Value.Month == month);
                onlineCourseData.Data.Add((decimal)transactionInMonth.Where(c => c.EntityTypeId == (int)EntityType.OnlineCourse && c.Status == (int)Models.Enum.Transaction.Status.Paid).Sum(c => c.TotalPayment));
                consultantData.Data.Add((decimal)transactionInMonth.Where(c => c.EntityTypeId == (int)EntityType.AdviceConsulting && c.Status == (int)Models.Enum.Transaction.Status.Paid).Sum(c => c.TotalPayment));
                workshopData.Data.Add((decimal)transactionInMonth.Where(c => c.EntityTypeId == (int)EntityType.WorkshopClass && c.Status == (int)Models.Enum.Transaction.Status.Paid).Sum(c => c.TotalPayment));
                trainingCourseData.Data.Add((decimal)transactionInMonth.Where(c => c.EntityTypeId == (int)EntityType.TrainingCourse && c.Status == (int)Models.Enum.Transaction.Status.Paid).Sum(c => c.TotalPayment));
            }
            return result;
        }
#pragma warning restore CS8629 // Nullable value type may be null.
        public async Task<IEnumerable<TransactionModel>> GetTransactions(EntityType? type = null)
        {
            Expression<Func<Transaction, bool>>? expression = null;
            if (type.HasValue)
            {
                expression = c => c.EntityTypeId == (int)type.Value;
            }
            var entities = await _uow.TransactionRepository.Get(expression, nameof(Transaction.Customer)
                                                                    , $"{nameof(Transaction.Customer)}.{nameof(Customer.User)}");
            entities = entities.Reverse();
            var models = _mapper.Map<IEnumerable<TransactionModel>>(entities);
            return models;
        }
    }
}
