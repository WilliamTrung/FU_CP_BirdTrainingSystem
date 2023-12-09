using AdviceConsultingSubsystem;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using TransactionSubsystem;

namespace AppService.AdviceConsultingService.Implementation
{
    public class ServiceTrainer : OtherService, IServiceTrainer
    {
        private readonly ITimetableFeature _timetable;
        public ServiceTrainer (IAdviceConsultingFeature consulting, IFeatureTransaction transaction, ITimetableFeature timetable) : base (consulting, transaction)
        {
            _timetable = timetable;
        }

        public async Task FinishAppointment(ConsultingTicketTrainerFinishModel ticket)
        {
            var listSlot = await _timetable.GetSlotRangeForConsultant(ticket.ActualSlotStart, ticket.ActualEndSlot);
            int totalSlot = listSlot.Count();

            dynamic price = await _transaction.CalculateConsultingTicketFinalPriceForTrainer(ticket.Id, totalSlot);
            decimal finalPrice = price.GetType().GetProperty("FinalPrice").GetValue(price, null);
            decimal discountedPrice = price.GetType().GetProperty("DiscountedPrice").GetValue(price, null);
            await _consulting.Trainer.FinishAppointment(ticket, finalPrice, discountedPrice);
        }

        public async Task UpdateAppointment(int ticketId, string ggmeetLink)
        {
            await _consulting.Trainer.UpdateAppointment(ticketId, ggmeetLink);
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListAssignedConsultingTicket(int trainerId)
        {
            return await _consulting.Trainer.GetListAssignedConsultingTicket(trainerId);
        }
    }
}