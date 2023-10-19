using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels.ConsultingTicket
{
    public class ConsultingTicketCreateNewModel
    {
        public int Id { get; set; }
        public CustomerServiceModel customer { get; set; } = null!;
        public AddressServiceModel Address { get; set; } = null!;
        public ConsultingTypeServiceModel ConsultingType { get; set; } = null!;
        public DateTime? ExpectedDate { get; set; }
        public int? ExpectedSlotStart { get; set; }
        public int? ExpectedSlotEnd { get; set; }
        public string ConsultingDetail { get; set; }
        public int Distance { get; set; }
        public bool OnlineOrOffline { get; set; }
        public decimal Price { get; set; }
        public ConsultingPricePolicyServiceModel ConsultingPricePolicy { get; set; } = null!;
        public DistancePriceServiceModel DistancePrice { get; set; } = null!;
    }
}
