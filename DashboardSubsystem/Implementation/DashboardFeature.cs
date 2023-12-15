using AppRepository.UnitOfWork;
using AutoMapper;
using Models.DashboardModels;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<TransactionModel>> GetTransactions()
        {
            var entities = await _uow.TransactionRepository.Get(null, nameof(Transaction.Customer)
                                                                    , $"{nameof(Transaction.Customer)}.{nameof(Customer.User)}");
            entities = entities.OrderByDescending(c => c.DateCreate);
            var models = _mapper.Map<IEnumerable<TransactionModel>>(entities);
            return models;
        }
    }
}
