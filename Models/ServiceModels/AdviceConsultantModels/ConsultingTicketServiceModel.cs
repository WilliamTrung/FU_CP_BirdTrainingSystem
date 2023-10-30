using Models.Enum.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels
{
    public class ConsultingTicketServiceModel
    {
        public int Id { get; set; }
        public CustomerServiceModel customer { get; set; } = null!;
        public AddressServiceModel Address { get; set; } = null!;
        public ConsultingTypeServiceModel ConsultingType { get; set; } = null!;
        public TrainerServiceModel Trainer { get; set; } = null!;
        public string ConsultingDetail { get; set; }
        public int Distance { get; set; }
        public bool OnlineOrOffline { get; set; }
        public string GgMeetLink { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public int ActualSlotStart { get; set; }
        public int? ActualEndSlot { get; set; }
        public string? Evidence { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int Status { get; set; }
        public ConsultingPricePolicyServiceModel ConsultingPricePolicy { get; set; } = null!;
        public DistancePriceServiceModel DistancePrice { get; set; } = null!;
    }
}
