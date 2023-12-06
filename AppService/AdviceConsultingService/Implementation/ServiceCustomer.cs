using AdviceConsultingSubsystem;
using Models.ServiceModels.AdviceConsultantModels;
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

        public async Task<ConsultingTicketDetailViewModel> GetConsultingTicketDetailByID(int customerId)
        {
            return await _consulting.Customer.GetConsultingTicketByID(customerId);
        }

        public async Task SendConsultingTicket(ConsultingTicketCreateNewModel consultingTicket, int distance)
        {
            dynamic price = await _transaction.CalculateConsultingTicketFinalPriceForCustomer(consultingTicket, distance);
            decimal finalPrice = price.GetType().GetProperty("FinalPrice").GetValue(price, null);
            decimal discountedPrice = price.GetType().GetProperty("DiscountedPrice").GetValue(price, null);
            await _consulting.Customer.SendConsultingTicket(consultingTicket, distance, finalPrice, discountedPrice);
        }

        public async Task<bool> ValidateBeforeUsingSendConsultingTicket(int customerId)
        {
            return await _consulting.Customer.ValidateBeforeUsingSendConsultingTicket(customerId);
        }

        public async Task<AddressServiceModel> GetListAddress(int customerId)
        {
            return await _consulting.Customer.GetListAddress(customerId);
        }

        public async Task<bool> CreateNewAddress(CreateNewAddressServiceModel address)
        {
            return await _consulting.Customer.CreateNewAddress(address);
        }
    }
}
