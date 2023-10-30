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
    public class ServiceCustomer : OtherService, IServiceCustomer
    {
        public ServiceCustomer(IAdviceConsultingFeature consulting, IFeatureTransaction transaction) : base(consulting, transaction) 
        {
        }
        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketByCustomerID(int customerId)
        {
            return await _consulting.Customer.GetListConsultingTicketByCustomerID(customerId);
        }

        public async Task<ConsultingTicketDetailViewModel> GetConsultingTicketDetailByID(int id)
        {
            return await _consulting.Customer.GetConsultingTicketByID(id);
        }

        public async Task SendConsultingTicket(ConsultingTicketCreateNewModel consultingTicket)
        {
            dynamic price = await _transaction.CalculateConsultingTicketFinalPrice(consultingTicket.Id);
            decimal finalPrice = price.FinalPrice;
            decimal discountedPrice = price.DiscountedPrice;
            await _consulting.Customer.SendConsultingTicket(consultingTicket, );
        }
    }
}
