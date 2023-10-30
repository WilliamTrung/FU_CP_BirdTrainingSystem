using AdviceConsultingSubsystem;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionSubsystem;

namespace AppService.AdviceConsultingService.Implementation
{
    internal class ServiceTrainer : OtherService, IServiceTrainer
    {
        public ServiceTrainer (IAdviceConsultingFeature consulting, IFeatureTransaction transaction) : base (consulting, transaction)
        {

        }

        public async Task FinishAppointment(ConsultingTicketTrainerFinishModel consultingTicket)
        {
            await _consulting.Trainer.FinishAppointment(consultingTicket);
        }

        public async Task UpdateAppointment(int ticketId, string ggmeetLink)
        {
            await _consulting.Trainer.UpdateAppointment(ticketId, ggmeetLink);
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> ViewAssignedAppointment(int id)
        {
            return await _consulting.Trainer.ViewAssignedAppointment(id);
        }
    }
}