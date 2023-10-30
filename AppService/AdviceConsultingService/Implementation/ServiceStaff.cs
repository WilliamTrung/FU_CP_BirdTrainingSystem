using AdviceConsultingSubsystem;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionSubsystem;

namespace AppService.AdviceConsultingService.Implementation
{
    public class ServiceStaff : OtherService, IServiceStaff
    {
        public ServiceStaff(IAdviceConsultingFeature consulting, IFeatureTransaction transaction) : base(consulting, transaction) 
        { 
        }
        public async Task ApproveConsultingTicket(int ticketId)
        {
            await _consulting.Staff.ApproveConsultingTicket(ticketId);
        }

        public async Task AssignTrainer(int trainerId, int ticketId)
        {
            await _consulting.Staff.AssignTrainer(trainerId, ticketId);
        }

        public async Task CancelConsultingTicket(int ticketId)
        {
            await _consulting.Staff.CancelConsultingTicket(ticketId);
        }

        public async Task<ConsultingTicketDetailViewModel> GetConsultingTicketByID(int id)
        {
            return await _consulting.Staff.GetConsultingTicketByID(id);
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketsByCustomerID(int customerID)
        {
            return await _consulting.Staff.GetListConsultingTicketsByCustomerID (customerID);
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketsByStatus(int status)
        {
            return await _consulting.Staff.GetListConsultingTicketsByStatus (status);
        }
    }
}
