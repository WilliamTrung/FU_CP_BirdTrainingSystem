using AppRepository.UnitOfWork;
using AutoMapper;
using Models.DashboardModels;
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

        public Task<DashboardWorkshop> GetDashboardWorkshop()
        {
            throw new NotImplementedException();
        }
    }
}
