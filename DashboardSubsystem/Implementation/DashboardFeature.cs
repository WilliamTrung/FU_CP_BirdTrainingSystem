using AppRepository.UnitOfWork;
using AutoMapper;
using Models.DashboardModels;
using Models.DashboardModels.PieCartModel;
using Models.Entities;
using Models.Enum;
using Models.ServiceModels;
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

        public ITopFeature Top { get ; }

        public DashboardFeature(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
            Top = new TopFeature(_uow);
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
            var approvedAmount = entities.Count(c => c.Status != (int)Models.Enum.ConsultingTicket.Status.Approved);

            var model = new DashboardConsultingTicket()
            {
                ApprovedTicket = approvedAmount,
                UnhandledTicket = unhandledAmount,
            };
            return model;
        }

        public async Task<DashboardOnlineCourse> GetDashboardOnlineCourse()
        {
            var entities = await _uow.CustomerOnlineCourseDetailRepository.Get(c => c.Status == (int)Models.Enum.OnlineCourse.Status.ACTIVE, nameof(CustomerOnlineCourseDetail.OnlineCourse));

            var activeCourses = entities.Select(c => c.OnlineCourse).Distinct();
            int activeCourseAmount = activeCourses.Count();
            var totalAttempts = entities.Count();
            var completed = entities.Count(c => c.Status == (int)Models.Enum.OnlineCourse.Customer.OnlineCourse.Status.Completed);

            var model = new DashboardOnlineCourse()
            {
                TotalAttempts = totalAttempts,
                ActiveCourseAmount = activeCourseAmount,
                CompletedAttempts = completed,
                RatioCompletedAndTotal = (float)completed / totalAttempts,
            };
            return model;
        }

        public async Task<DashboardWorkshop> GetDashboardWorkshop()
        {
            var entities = await _uow.CustomerWorkshopClassRepository.Get(c => c.WorkshopClass.Status == (int)Models.Enum.Workshop.Class.Status.OnGoing, nameof(CustomerWorkshopClass.WorkshopClass));
            var ongoingClassAmount = entities.Select(c => c.WorkshopClass).Distinct().Count();
            var enrolledAmount = entities.Count();   
            
         
            var model = new DashboardWorkshop()
            {
                OnGoingClassAmount = ongoingClassAmount,
                EnrolledAmount = enrolledAmount,
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
        public async Task<IEnumerable<TrainerContributionModel>> GetTrainerContributionModels(int month, int year)
        {
            var result = new List<TrainerContributionModel>();
            IEnumerable<TrainerSlot> trainerSlots;
            var currentTime = DateTime.UtcNow.AddHours(7);
            if (month == currentTime.Month && year == currentTime.Year)
            {
                trainerSlots = await _uow.TrainerSlotRepository.Get(c => c.Date.Month == month
                                                                        && c.Date.Year == year
                                                                        && c.Date.Day <= currentTime.Day
                                                                        && c.Status == (int)TrainerSlotStatus.Enabled
                                                                        , nameof(Trainer)
                                                                        , $"{nameof(Trainer)}.{nameof(Trainer.TrainerSkills)}"
                                                                        , $"{nameof(Trainer)}.{nameof(Trainer.User)}");
            } else
            {
                trainerSlots = await _uow.TrainerSlotRepository.Get(c => c.Date.Month == month
                                                                                       && c.Date.Year == year
                                                                                       && c.Status == (int)TrainerSlotStatus.Enabled
                                                                                       , nameof(Trainer)
                                                                                       , $"{nameof(Trainer)}.{nameof(Trainer.TrainerSkills)}");
            }
            //get trainer with most consultant slot
            var consultantSlots = trainerSlots.Where(c => c.EntityTypeId == (int)Models.Enum.EntityType.AdviceConsulting);
            var mostConsultation = GetMostConsultantSlotTrainer(consultantSlots);
            var workshopSlots = trainerSlots.Where(c => c.EntityTypeId == (int)EntityType.WorkshopClass);
            var mostWorkshopHosted = GetMostWorkshopSlotTrainer(workshopSlots);
            var traniningSlots = trainerSlots.Where(c => c.EntityTypeId == (int)EntityType.TrainingCourse);
            var mostTraining = GetMostTrainingSlotTrainer(traniningSlots);

            var mostContribute = GetMostContributeSlots(trainerSlots);
            if(mostContribute != null)
            {
                result.Add(mostContribute);
            }
            if (mostConsultation != null)
            {
                result.Add(mostConsultation);
            }
            if(mostWorkshopHosted != null)
            {
                result.Add(mostWorkshopHosted);
            }
            if(mostTraining != null)
            {
                result.Add(mostTraining);
            }
            if(result.Count < 4)
            {
                if (month == 1)
                {
                    var prevResult = await GetTrainerContributionModels(12, year - 1);
                    result = prevResult.ToList();
                }
                else
                {
                    var prevResult = await GetTrainerContributionModels(month - 1, year);
                    result = prevResult.ToList();
                }
            }
            return result;
        }
        private TrainerContributionModel? GetMostConsultantSlotTrainer(IEnumerable<TrainerSlot> consultantSlots)
        {
            var groupConsultant = consultantSlots.GroupBy(c => c.TrainerId);
            groupConsultant = groupConsultant.OrderByDescending(c => c.Count());
            try
            {
                var mostConsultantSlots = groupConsultant.First();
                var mostConsultant = mostConsultantSlots.First().Trainer;
                return new TrainerContributionModel
                {
                    Trainer = _mapper.Map<TrainerModel>(mostConsultant),
                    Detail = "Most advice consultation for customer!",
                    SlotCount = mostConsultantSlots.Count(),
                };
            } catch
            {
                return null;
            }
            
        }
        private TrainerContributionModel? GetMostWorkshopSlotTrainer(IEnumerable<TrainerSlot> workshopSlots)
        {
            var groupWorkshop = workshopSlots.GroupBy(c => c.TrainerId);
            groupWorkshop = groupWorkshop.OrderByDescending(c => c.Count());
            try
            {
                var mostWorkshopSlots = groupWorkshop.First();
                var mostWorkshop = mostWorkshopSlots.First().Trainer;
                return new TrainerContributionModel
                {
                    Trainer = _mapper.Map<TrainerModel>(mostWorkshop),
                    Detail = "Most workshop hosted!",
                    SlotCount = mostWorkshopSlots.Count(),
                };
            }
            catch
            {
                return null;
            }
        }
        private TrainerContributionModel? GetMostTrainingSlotTrainer(IEnumerable<TrainerSlot> trainingSlots)
        {
            var groupTraining = trainingSlots.GroupBy(c => c.TrainerId);
            groupTraining = groupTraining.OrderByDescending(c => c.Count());
            try
            {
                var mostTrainingSlots = groupTraining.First();
                var mostTraining = mostTrainingSlots.First().Trainer;
                return new TrainerContributionModel
                {
                    Trainer = _mapper.Map<TrainerModel>(mostTraining),
                    Detail = "Most tranining birds duration!",
                    SlotCount = mostTrainingSlots.Count(),
                };
            }
            catch
            {
                return null;
            }
        }
        private TrainerContributionModel? GetMostContributeSlots(IEnumerable<TrainerSlot> slots)
        {
            var groupTrainer = slots.GroupBy(c => c.TrainerId);
            groupTrainer = groupTrainer.OrderByDescending(c => c.Count());
            try
            {
                var mostSlots = groupTrainer.First();
                var mostWorkedSlot = mostSlots.First().Trainer;
                return new TrainerContributionModel
                {
                    Trainer = _mapper.Map<TrainerModel>(mostWorkedSlot),
                    Detail = "Most working hours!",
                    SlotCount = mostSlots.Count(),
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<DashboardTrainingCourse> GetDashboardTrainingCourse()
        {
            var progresses = await _uow.BirdTrainingProgressRepository.Get(c => c.Status == (int)Models.Enum.BirdTrainingProgress.Status.Assigned
                                                                             || c.Status == (int)Models.Enum.BirdTrainingProgress.Status.Training
                                                                             || c.Status == (int)Models.Enum.BirdTrainingProgress.Status.WaitingForTimetable
                                                                             || c.Status == (int)Models.Enum.BirdTrainingProgress.Status.WaitingForAssign
                                                                             , nameof(BirdTrainingProgress.BirdTrainingCourse)
                                                                             , $"{nameof(BirdTrainingProgress.BirdTrainingCourse)}.{nameof(BirdTrainingCourse.TrainingCourse)}");
            var trainingCourses = progresses.Select(c => c.BirdTrainingCourse.TrainingCourse).Distinct().ToList();
            var registration = progresses.Where(c => c.Status == (int)Models.Enum.BirdTrainingProgress.Status.Assigned
                                                  || c.Status == (int)Models.Enum.BirdTrainingProgress.Status.Training);
            var unhandledRequest = progresses.Where(c => c.Status == (int)Models.Enum.BirdTrainingProgress.Status.WaitingForTimetable
                                                      || c.Status == (int)Models.Enum.BirdTrainingProgress.Status.WaitingForAssign);
            var model = new DashboardTrainingCourse
            {
                ClientAmount = registration.Count(),
                OnGoingCourseAmount = trainingCourses.Count(),
                UnhandledAttempts = unhandledRequest.Count(),
            };
            return model;
        }
#pragma warning disable CS8629 // Nullable value type may be null.
        public async Task<PieChartServicesData> GetRatioTotalServices(int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year
                                                                        && c.Status == (int)Models.Enum.Transaction.Status.Paid
                                                                        && (
                                                                        c.EntityTypeId == (int)Models.Enum.EntityType.AdviceConsulting
                                                                        || c.EntityTypeId == (int)Models.Enum.EntityType.TrainingCourse
                                                                        || c.EntityTypeId == (int)Models.Enum.EntityType.WorkshopClass
                                                                        || c.EntityTypeId == (int)Models.Enum.EntityType.OnlineCourse
                                                                        ));
            var model = new PieChartServicesData();

            var onlineCourseTransactions = transactions.Where(c => c.EntityTypeId == (int)Models.Enum.EntityType.OnlineCourse);
            model.Labels.Add("Online Course");
            model.Data.Add((decimal)onlineCourseTransactions.Sum(c => c.TotalPayment));

            var consultingTransactions = transactions.Where(c => c.EntityTypeId == (int)Models.Enum.EntityType.AdviceConsulting);
            model.Labels.Add("Consultation");
            model.Data.Add((decimal)consultingTransactions.Sum(c => c.TotalPayment));

            var workshopTransactions = transactions.Where(c => c.EntityTypeId == (int)Models.Enum.EntityType.WorkshopClass);
            model.Labels.Add("Workshop");
            model.Data.Add((decimal)workshopTransactions.Sum(c => c.TotalPayment));

            var trainingCourseTransactions = transactions.Where(c => c.EntityTypeId == (int)Models.Enum.EntityType.TrainingCourse);
            model.Labels.Add("Training Course");
            model.Data.Add((decimal)trainingCourseTransactions.Sum(c => c.TotalPayment));

            return model;
        }
#pragma warning restore CS8629 // Nullable value type may be null.
    }
}
